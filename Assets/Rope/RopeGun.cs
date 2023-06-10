using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _speed;
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private float _spring = 100f;
    [SerializeField] private float _damper = 100f;
    [SerializeField] private float _maxDistance = 3f;
    [SerializeField] private float _climbSpeed = 5f;
    [SerializeField] private Transform _ropeSpawn;

    [SerializeField] private RopeState _currentRopeState;

    [SerializeField] private float _length;

    [SerializeField] private RopeRenderer _ropeRenderer;

    [SerializeField] private Player _player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            Shot();
        }
        if (_currentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(_ropeSpawn.position, _hook.transform.position);
            if (distance > 20f)
            {
                _hook.gameObject.SetActive(false);
                _currentRopeState = RopeState.Disabled;
                _ropeRenderer.HideLine();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentRopeState == RopeState.Active)
            {
                Debug.Log("da");
                if (_player.IsGrounded() == false)
                {
                    _player.Jump();
                }
            }
            DestroySpring();
        }
        if (_currentRopeState == RopeState.Fly || _currentRopeState == RopeState.Active)
        {
            _ropeRenderer.DrawLine(_ropeSpawn.position, _hook.transform.position, _length);
        }

        if (_currentRopeState == RopeState.Active)
        {
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                if (_length >= 0)
                {
                    _length = _length - Input.GetAxisRaw("Vertical") * _climbSpeed * Time.deltaTime;
                    ChangeLength(_length);
                }
                else
                {
                    _length = 0.01f;
                }

            }
        }
    }

    void Shot()
    {
        _length = 0;
        if (_springJoint)
        {
            Destroy(_springJoint);
        }
        _hook.gameObject.SetActive(true);
        _hook.StopFix();
        _hook.transform.position = _spawn.position;
        _hook.transform.rotation = _spawn.rotation;
        _hook.SetVelocity(_speed);

        _currentRopeState = RopeState.Fly;
    }


    public void ChangeLength(float length)
    {
        if (_springJoint != null)
        {
            
                _springJoint.maxDistance = length;
            
            
        }

    }

    public void CreateSpring()
    {
        if (_springJoint == null)
        {
            _springJoint = gameObject.AddComponent<SpringJoint>();
            _springJoint.connectedBody = _hook.GetComponent<Rigidbody>();
            _springJoint.anchor = _ropeSpawn.localPosition;
            _springJoint.connectedAnchor = Vector3.zero;
            _springJoint.spring = _spring;
            _springJoint.damper = _damper;
            
            _springJoint.autoConfigureConnectedAnchor = false;

            _length = Vector3.Distance(_ropeSpawn.position, _hook.transform.position);
            _springJoint.maxDistance = _length;

            _currentRopeState = RopeState.Active;
        }
        
    }

    public void DestroySpring()
    {
        if (_springJoint)
        {
            Destroy(_springJoint);
            _currentRopeState = RopeState.Disabled;
            _hook.gameObject.SetActive(false);
            _ropeRenderer.HideLine();
        }
    }

}
