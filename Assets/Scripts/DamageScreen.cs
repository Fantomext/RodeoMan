using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    [SerializeField] private Image DamageImage;

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
        DamageImage.enabled = true;
        for (float t = 1f; t > 0f; t-= Time.deltaTime)
        {
            DamageImage.color = new Color(1f,0f,0f, t);
            yield return null;
        }
        DamageImage.enabled = false;
    }

    public IEnumerator ShowEffectBlue()
    {
        DamageImage.enabled = true;
        for (float t = 1f; t > 0f; t -= Time.deltaTime)
        {
            DamageImage.color = new Color(0f, 1f, 0.6352941176f, t);
            yield return null;
        }
        DamageImage.enabled = false;
    }

}
