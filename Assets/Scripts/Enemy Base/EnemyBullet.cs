using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float _speed = 15f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Transform playerTransform = FindObjectOfType<Player>().transform;
        Vector3 toPlayer = playerTransform.position - transform.position;

        transform.rotation = Quaternion.LookRotation(toPlayer);

        _rigidbody.velocity = toPlayer.normalized * _speed;
    }

    
}
