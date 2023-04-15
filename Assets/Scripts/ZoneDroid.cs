using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDroid : MonoBehaviour
{
    private Rigidbody _rigibody;
    private Transform _playerTransform;

    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _timeToReachSpeed = 1.5f;
    void Start()
    {
        _playerTransform = FindObjectOfType<Player>().transform;
        _rigibody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;

        Vector3 force = _rigibody.mass * (toPlayer * _speed - _rigibody.velocity) / _timeToReachSpeed;

        _rigibody.AddForce(force);
    }
}
