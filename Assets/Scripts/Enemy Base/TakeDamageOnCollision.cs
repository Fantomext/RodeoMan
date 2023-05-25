using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    private EnemyHealth _enemyHealth;
   [SerializeField] private bool _dieOnAnyCollision;

    private void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponentInParent<LightSaber>() != null)
        {
            LightSaber lightSaber = collision.gameObject.GetComponentInParent<LightSaber>();
            _enemyHealth.TakeDamage(lightSaber.DamageSaber());
        }
        if (collision.rigidbody)
        {
            if (collision.rigidbody.TryGetComponent<Bullet>(out var bullet))
            {
                _enemyHealth.TakeDamage(bullet.DamageBullet());
            }
        }
        if (_dieOnAnyCollision)
        {
            _enemyHealth.TakeDamage(1000);
        }
        
    }
}
