using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMove : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _distance = 1f;
    private void Update()
    {
        float move = Mathf.Sin(Time.time * _speed) * _distance;
        transform.position += new Vector3(0f, move * Time.deltaTime, 0f);
    }
}
