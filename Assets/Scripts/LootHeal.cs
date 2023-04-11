using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    private int _healthValue = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            playerHealth.AddHealth(_healthValue);
            Destroy(gameObject);
        }


    }
}
