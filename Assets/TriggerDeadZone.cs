using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeadZone : MonoBehaviour
{
    [SerializeField] Transform spawnPosition;
    [SerializeField] PlayerHealth _player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<Player>())
            {
                _player.transform.position = new Vector3(spawnPosition.position.x, spawnPosition.position.y, 0f);
                _player.TakeDamage(1);
            }
        }
    }
}
