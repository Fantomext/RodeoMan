using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private int _maxHealth = 5;

    [SerializeField] private bool _invulnerable = false;

    //[SerializeField] private AudioSource _takeDamageSound;
    //[SerializeField] private AudioSource _healSounde;

    [SerializeField] private HealthUI _healthUI;
    //[SerializeField] private DamageScreen _damageScreen;
    //[SerializeField] private Blink _blink;

    [SerializeField] private UnityEvent eventOnTakeDamage;
    [SerializeField] private UnityEvent eventOnAddHealth;

    private void Start()
    {
        _healthUI.Setup(_maxHealth);
        _healthUI.DisplayHealth(_health);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void TakeDamage(int damageValue)
    {
        if (_invulnerable == false)
        {
            _health -= damageValue;
            if (_health <= 0)
            {
                Die();
            }
            _invulnerable = true;
            //_takeDamageSound.Play();
            _healthUI.DisplayHealth(_health);
            //_damageScreen.StartEffectRed();
            //_blink.StartBlink();
            Invoke(nameof(StopInvulnerable), 1f);

            eventOnTakeDamage.Invoke();
        }
        
    }

    void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        _health += healthValue;
        if (_health >= _maxHealth)
        {
            _health = _maxHealth;
        }
        _healthUI.DisplayHealth(_health);
        //_healSounde.Play();
        //_damageScreen.StartEffectBlue();
        eventOnAddHealth.Invoke();
    }

    void Die()
    {
        Debug.Log("You lose");
    }
   
}
