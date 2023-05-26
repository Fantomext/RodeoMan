using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] private Vector3 _leftEueler;
    [SerializeField] private Vector3 _rightEueler;

    [SerializeField] private float _rotationSpeed = 15f;

    [SerializeField] private Vector3 _targetEuler;

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * _rotationSpeed);
    }

    public void RotateLeft()
    {
        _targetEuler = _leftEueler;
    }

    public void RotateRight()
    {
        _targetEuler = _rightEueler;
    }
}
