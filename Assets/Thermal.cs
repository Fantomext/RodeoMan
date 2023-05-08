using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermal : MonoBehaviour
{
    Rigidbody _rigibody;
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _maxRotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _rigibody = GetComponent<Rigidbody>();
        _rigibody.AddRelativeForce(_velocity, ForceMode.VelocityChange);
        _rigibody.angularVelocity = new Vector3(Random.Range(-_maxRotationSpeed, _maxRotationSpeed),
                                                Random.Range(-_maxRotationSpeed, _maxRotationSpeed),
                                                Random.Range(-_maxRotationSpeed, _maxRotationSpeed));
    }

   
}
