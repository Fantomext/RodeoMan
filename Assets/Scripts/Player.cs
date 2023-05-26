using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private bool _grounded;
    [SerializeField] private float _maxSpeed;
    private bool _isWalking = false;
    private bool _isHitMelee = false;
    private bool _isHitEnd = true;

    [SerializeField] private Transform _colliderTransform;
    [SerializeField] private Gun _gun;
    [SerializeField] private PlayerArmory _playerArmory;
    [SerializeField] private LightSaber _lightSaber;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || _grounded == false)
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15f);
        }
        else
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, Vector3.one, Time.deltaTime * 15f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_grounded)
            {
                _rigidbody.AddForce(0f,_jumpSpeed,0f, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKey(KeyCode.E) && _isHitEnd)
        {
            StartCoroutine(Hit());
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float speedMultiplier = 1f;

        if (_grounded == false)
        {
            speedMultiplier = 0.1f;
        }

        if (_rigidbody.velocity.x > _maxSpeed && Input.GetAxisRaw("Horizontal") > 0)
        {
            speedMultiplier = 0;
        }
        if (_rigidbody.velocity.x < -_maxSpeed && Input.GetAxisRaw("Horizontal") < 0)
        {
            speedMultiplier = 0;
        }

        _rigidbody.AddForce(Input.GetAxisRaw("Horizontal") * _moveSpeed * speedMultiplier, 0f,0f, ForceMode.VelocityChange);    

        if (_grounded)
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x * _friction, 0f, 0f, ForceMode.VelocityChange);

            if (_rigidbody.velocity.x != 0)
            {
                _isWalking = true;
            }
            else
            {
                _isWalking = false;
            }
        }
        
    }

    IEnumerator Hit()
    {
        SelectedGun();
        _isHitEnd = false;
        HitStart();
        yield return new WaitForSeconds(0.5f);
        HitEnd();
        yield return new WaitForSeconds(0.2f);
        _isHitEnd = true;
    }

    public void HitStart()
    {
        _lightSaber.ShowLightSaber();
        _lightSaber.PlaySoundHit();
        _gun.Deactivate();
        _isHitMelee = true;
    }

    public void HitEnd()
    {
        _lightSaber.HideLightSaber();
        _gun.Activate();
        _isHitMelee = false;
    }

    public void SelectedGun()
    {
        _gun = _playerArmory.CurrentGunReturn(); 
    }
    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle < 45f)
            {
                _grounded = true;
            }
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        _grounded = false;
    }

    public bool IsWalking()
    {
        return _isWalking;
    }

    public bool IsHit()
    {
        return _isHitMelee;
    }
}
