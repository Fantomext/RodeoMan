using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    private EnemyHealth _enemyHealth;

    private void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<LightSaber>(out var lightSaber))
        {
            _enemyHealth.TakeDamage(lightSaber.DamageSaber());
        }
        if (collision.rigidbody)
        {
            if (collision.rigidbody.TryGetComponent<Bullet>(out var bullet))
            {
                _enemyHealth.TakeDamage(bullet.DamageBullet());
            }
        }
        
    }
}
