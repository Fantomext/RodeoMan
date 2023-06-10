using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    [SerializeField] private Image _damageImage;

    public void StartEffectRed()
    {
        StartCoroutine(ShowEffectRed());
    }
    public void StartEffectBlue()
    {
        StartCoroutine(ShowEffectBlue());
    }
    public IEnumerator ShowEffectRed()
    {
        _damageImage.enabled = true;
        for (float t = 1f; t > 0f; t-= Time.deltaTime)
        {
            _damageImage.color = new Color(1f,0f,0f, t);
            yield return null;
        }
        _damageImage.enabled = false;
    }

    public IEnumerator ShowEffectBlue()
    {
        _damageImage.enabled = true;
        for (float t = 1f; t > 0f; t -= Time.deltaTime)
        {
            _damageImage.color = new Color(0f, 1f, 0.6352941176f, t);
            yield return null;
        }
        _damageImage.enabled = false;
    }

}
