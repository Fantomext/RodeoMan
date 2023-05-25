using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    [SerializeField] float _distanceToActivate;
    [SerializeField] Activate _activator;
    private bool _isActive = true;

    private void Start()
    {
        _activator = FindObjectOfType<Activate>();
        _activator.AddObjectToActivate(this);
    }
    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);
        if (_isActive == true)
        {
            if (distance > _distanceToActivate + 2f)
            {
                Deactivate();
            }
            
        }
        else
        {
            if (distance < _distanceToActivate)
            {
                Activate();
            }
        }
        
    }

    public void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }
    
    public void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    public void OnDestroy()
    {
        _activator.DeleteObjectToActivate(this);
    }

    private void OnDrawGizmosSelected()
    {
        Handles.DrawWireDisc(transform.position, Vector3.forward, _distanceToActivate);
    }
}
