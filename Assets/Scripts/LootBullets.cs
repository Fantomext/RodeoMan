using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullets : MonoBehaviour
{
    [SerializeField] private int _gunIndex;
    [SerializeField] private int _countBullets;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent<PlayerArmory>(out var playerArmory))
        {
            if (other.gameObject.GetComponentInParent<LightSaber>() == null)
            {
                playerArmory.AddBullets(_gunIndex, _countBullets);
                Destroy(gameObject);
            }
        }
    }
}
