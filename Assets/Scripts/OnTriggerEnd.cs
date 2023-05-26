using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnd : MonoBehaviour
{
    [SerializeField] UnityEvent _endEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.gameObject.name == "Dart Vader")
        {
            _endEvent.Invoke();
            Time.timeScale = 0;
        }
    }
}
