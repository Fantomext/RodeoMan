using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;
    [SerializeField] private int _damage = 1;
    [SerializeField] private Collider[] _ignoreColliders;
 
    void Start()
    {
        Destroy(gameObject, 3f);
    }
    public int DamageBullet()
    {
        return _damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }



}
