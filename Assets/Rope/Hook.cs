using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private FixedJoint _fixedJoint;
    [SerializeField] private Rigidbody _rigibody;
    [SerializeField] private Collider _collider;
    [SerializeField] private Collider _playerColider;
    [SerializeField] private RopeGun _ropeGun;
    [SerializeField] private Transform _hookRotation;

    private void Start()
    {
        Physics.IgnoreCollision(_collider, _playerColider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_fixedJoint == null)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();
            if (collision.rigidbody)
            {
                _fixedJoint.connectedBody = collision.rigidbody;
            }
            _ropeGun.CreateSpring();
        }
    }

    public void StopFix()
    {
        if (_fixedJoint)
        {
            Destroy(_fixedJoint);
        }
    }

    public void SetVelocity(float speed)
    {
        _rigibody.velocity = transform.forward * speed;
    }
}
