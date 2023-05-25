using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{

    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private bool _dieOnAnyCollision = false;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<LightSaber>() != null)
        {
            LightSaber lightSaber = other.gameObject.GetComponentInParent<LightSaber>();
            _enemyHealth.TakeDamage(lightSaber.DamageSaber());
        }

        if (other.gameObject.GetComponentInParent<Bullet>())
        {
            Bullet bullet = other.gameObject.GetComponentInParent<Bullet>();
            _enemyHealth.TakeDamage(bullet.DamageBullet());
        }

        if (_dieOnAnyCollision)
        {
            if (other.isTrigger == false)
            {
                _enemyHealth.TakeDamage(10000);
            }
        }
    }
}
