using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidB1 : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Collider _ignoreColliders;
    
    public void Create()
    {
        GameObject _bullet = Instantiate(_bulletPrefab, _spawnPoint.position, Quaternion.identity);
        Collider bulletCollider = _bullet.GetComponentInChildren<Collider>();
        Physics.IgnoreCollision(bulletCollider, _ignoreColliders);
    }
}
