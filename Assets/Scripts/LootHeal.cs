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
            Debug.Log(other.attachedRigidbody);
            if (other.gameObject.GetComponentInParent<LightSaber>() == null)
            {
                
            }
            if (other.attachedRigidbody.TryGetComponent<Bullet>(out var bullet))
            {
                Debug.Log("true");
                Physics.IgnoreCollision(other, bullet.GetComponent<Collider>());
            }
            else
            {
                playerHealth.AddHealth(_healthValue);
                Destroy(gameObject);
            }
        }
    }
}
