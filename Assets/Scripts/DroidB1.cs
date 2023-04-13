using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidB1 : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Collider _ignoreColliders;
    [SerializeField] Transform _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        Vector3 toPlayer = _player.position - transform.position;
        toPlayer.y = 0;
        transform.rotation = Quaternion.LookRotation(toPlayer);
    }

    public void Create()
    {
        GameObject _bullet = Instantiate(_bulletPrefab, _spawnPoint.position, Quaternion.identity);
        Collider bulletCollider = _bullet.GetComponentInChildren<Collider>();
        Physics.IgnoreCollision(bulletCollider, _ignoreColliders);
    }
}
