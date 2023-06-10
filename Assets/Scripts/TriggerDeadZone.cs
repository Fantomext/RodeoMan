using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeadZone : MonoBehaviour
{
    [SerializeField] Transform _spawnPosition;
    [SerializeField] PlayerHealth _player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<Player>())
            {
                _player.transform.position = new Vector3(_spawnPosition.position.x, _spawnPosition.position.y, 0f);
                _player.TakeDamage(1);
            }
        }
    }
}
