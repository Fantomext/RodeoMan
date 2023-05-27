using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 1;
    [SerializeField] private UnityEvent _eventOnDie;
    [SerializeField] private UnityEvent _eventOnTakeDamage;
    public void TakeDamage(int damageValue)
    {

        
        _health -= damageValue;

        if (_health <= 0)
        {
            _eventOnDie.Invoke();
            Die();
        }
        else
        {
            _eventOnTakeDamage.Invoke();
        }

    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
