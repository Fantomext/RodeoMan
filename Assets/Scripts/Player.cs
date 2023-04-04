using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private bool _grounded;
    [SerializeField] private float _maxSpeed;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_grounded)
            {
                rigidbody.AddForce(0f,_jumpSpeed,0f, ForceMode.VelocityChange);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speedMultiplier = 1f;

        if (_grounded == false)
        {
            speedMultiplier = 0.3f;
        }

        if (rigidbody.velocity.x > _maxSpeed && Input.GetAxisRaw("Horizontal") > 0)
        {
            speedMultiplier = 0;
        }
        if (rigidbody.velocity.x < -_maxSpeed && Input.GetAxisRaw("Horizontal") < 0)
        {
            speedMultiplier = 0;
        }

        rigidbody.AddForce(Input.GetAxisRaw("Horizontal") * _moveSpeed * speedMultiplier, 0f,0f, ForceMode.VelocityChange);

        if (_grounded)
        {
            rigidbody.AddForce(-rigidbody.velocity.x * _friction, 0f, 0f, ForceMode.VelocityChange);
        }
        
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
}
