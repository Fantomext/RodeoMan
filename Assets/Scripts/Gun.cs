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
    [SerializeField] private Collider _ignoreColliders;
    [SerializeField] private Gun _gun;

    private void Start()
    {
        _gun = GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer > _shotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0;
                GameObject newBullet = Instantiate(_bulletPrefab, _spawn.position, _spawn.rotation);
                newBullet.GetComponent<Rigidbody>().velocity = _spawn.forward * _bulletSpeed;
                Collider bulletCollider = newBullet.GetComponentInChildren<Collider>();
                Physics.IgnoreCollision(bulletCollider, _ignoreColliders);
                _shotSound.pitch = Random.Range(0.8f, 1.2f);
                _shotSound.Play();
                _flash.SetActive(true);
                Invoke(nameof(HideFlash), 0.08f);
            }
        }
    }

    public void HideFlash()
    {
        _flash.SetActive(false);
    }

    public void ShowGun()
    {
        _gun.gameObject.SetActive(true);
    }

    public void HideGun()
    {
        _gun.gameObject.SetActive(false);
    }
}
