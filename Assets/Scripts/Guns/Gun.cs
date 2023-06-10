using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _bulletSpeed = 5f;
    [SerializeField] private float _shotPeriod = 0.9f;
    [SerializeField] private float _timer = 0;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private GameObject _flash;
    [SerializeField] private Collider[] _ignoreColliders;
    [SerializeField] private Gun _gun;
    [SerializeField] private ParticleSystem shotEffect;

    private void Start()
    {
        _gun = GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.unscaledDeltaTime;
        
        if (_timer > _shotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                Shot();
            }
        }
    }

    public virtual void Shot()
    {
        _timer = 0;
        GameObject newBullet = Instantiate(_bulletPrefab, _spawn.position, _spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = _spawn.forward * _bulletSpeed;
        Collider bulletCollider = newBullet.GetComponentInChildren<Collider>();
        for (int i = 0; i < _ignoreColliders.Length; i++)
        {
            if (_ignoreColliders[i] != null)
            {
                Physics.IgnoreCollision(bulletCollider, _ignoreColliders[i]);
            }
        }
        _shotSound.pitch = Random.Range(0.8f, 1.2f);
        _shotSound.Play();
        _flash.SetActive(true);
        shotEffect.Play();
        Invoke(nameof(HideFlash), 0.08f);
    }

    public void HideFlash()
    {
        _flash.SetActive(false);
    }


    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int countBullets)
    {

    }
}
