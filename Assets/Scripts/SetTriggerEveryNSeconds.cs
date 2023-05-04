using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNSeconds : MonoBehaviour
{
    [SerializeField] private string _attack = "Attack";

    [SerializeField] private Animator _animator;
    [SerializeField] private float _attackPeriod = 7f;
    private float _timer = 0;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _attackPeriod)
        {
            _timer = 0;
            _animator.SetTrigger(_attack);
        }
    }
}
