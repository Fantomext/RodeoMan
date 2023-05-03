using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _angleRotate = 105f;
    void Start()
    {
        _player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toPlayer = _player.position - transform.position;
        toPlayer.y = 0;
        Quaternion rotateToplayer = Quaternion.LookRotation(toPlayer);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(_angleRotate, rotateToplayer.ToEulerAngles()), Time.deltaTime * _rotationSpeed);
        
    }
}
