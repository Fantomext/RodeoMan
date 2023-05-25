using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    [SerializeField] private Transform _leftTarget;
    [SerializeField] private Transform _rightTarget;

    [SerializeField] private float _speed;

    [SerializeField] private float StopTime;

    [SerializeField] private bool _isStopped;

    [SerializeField] private Direction _currentDirection;

    [SerializeField] private UnityEvent _eventOnLeftTarget;
    [SerializeField] private UnityEvent _eventOnRightTarget;

    [SerializeField] private Transform _rayStart;

    private void Start()
    {
        _leftTarget.parent = null;
        _rightTarget.parent = null;
    }
    // Update is called once per frame
    void Update()
    {
        if (_isStopped == true)
        {
            return;
        }

        if (_currentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * _speed, 0f, 0f);
            if (transform.position.x < _leftTarget.position.x)
            {
                _currentDirection = Direction.Right;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), StopTime);
                _eventOnLeftTarget.Invoke();
            }
        }

        if (_currentDirection == Direction.Right)
        {
            transform.position += new Vector3(_speed * Time.deltaTime, 0f,0f);
            if (transform.position.x > _rightTarget.position.x)
            {
                _currentDirection = Direction.Left;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), StopTime);
                _eventOnRightTarget.Invoke();
            }
        }
        RaycastHit hit;
        if (Physics.Raycast(_rayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }

    public void ContinueWalk()
    {
        _isStopped = false;
    }
}
