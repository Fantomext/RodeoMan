using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{

    private EnemyHealth _enemyHealth;

    private void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.GetComponentInParent<LightSaber>());

        if (other.gameObject.GetComponentInParent<LightSaber>() != null)
        {
            LightSaber lightSaber = other.gameObject.GetComponentInParent<LightSaber>();
            _enemyHealth.TakeDamage(lightSaber.DamageSaber());
        }
    }
}
