using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{
    [SerializeField] LightSaber _lightSaber;
    [SerializeField] int _damageHit = 1;
    [SerializeField] AudioSource audioSource;
    private void Awake()
    {
        _lightSaber = GetComponent<LightSaber>();
        
    }

    
    public int DamageSaber()
    {
        return _damageHit;
    }
    private void Start()
    {
        _lightSaber.gameObject.SetActive(false);
    }
    public void PlaySoundHit()
    {
        audioSource.pitch = Random.Range(1.3f, 1.5f);
        audioSource.Play();
    }
    public void ShowLightSaber()
    {
        _lightSaber.gameObject.SetActive(true);
    }

    public void HideLightSaber()
    {
        _lightSaber.gameObject.SetActive(false);
    }
}
