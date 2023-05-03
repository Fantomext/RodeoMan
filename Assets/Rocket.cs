using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Transform _player;
    private Rigidbody _rigibody;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotateSpeed = 7f;
    void Start()
    {
        _rigibody = GetComponent<Rigidbody>();
        _player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        Vector3 toPlayer = _player.position - transform.position;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(toPlayer, Vector3.forward), Time.deltaTime * _rotateSpeed);

        _rigibody.velocity = transform.forward.normalized * _speed;
    }
}
