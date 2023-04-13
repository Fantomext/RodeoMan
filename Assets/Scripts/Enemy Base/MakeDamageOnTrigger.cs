using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            if (other.gameObject.GetComponentInParent<LightSaber>() == null)
            {
                playerHealth.TakeDamage(_damageValue);
            }
        }
    }
}
