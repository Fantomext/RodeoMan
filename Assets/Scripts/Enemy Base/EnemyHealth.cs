using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 1;
    [SerializeField] private UnityEvent _eventOnDie;
    [SerializeField] private UnityEvent _eventOnTakeDamage;
    public void TakeDamage(int damageValue)
    {

        _eventOnTakeDamage.Invoke();
        _health -= damageValue;
        if (_health == 1)
        {
            _eventOnDie.Invoke();
        }
        if (_health <= 0)
        {
            Die();
        }
        
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
