using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    private int _damageValue = 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.TryGetComponent<PlayerHealth>(out var playerHealth))
            {
                playerHealth.TakeDamage(_damageValue);
            }
        }
        
    }
}
