using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Blaster : Gun
{
    [Header("Blaster prop")]
    [SerializeField] private int _bulletsCount;
    [SerializeField] private TMP_Text text;
    [SerializeField] private PlayerArmory playerArmory;

    public override void Shot()
    {
        base.Shot();
        _bulletsCount -= 1;
        UpdateText();
        if (_bulletsCount == 0)
        {
            playerArmory.TakeGunByIndex(0);
        }
    }

    public override void Activate()
    {
        base.Activate();
        text.enabled = true;
        UpdateText();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        text.enabled = false;
    }

    public void UpdateText()
    {
        text.text = "Bullet: " + _bulletsCount.ToString();
    }

    public override void AddBullets(int countBullets)
    {
        base.AddBullets(countBullets);
        _bulletsCount += countBullets;
        UpdateText();
        playerArmory.TakeGunByIndex(1);
    }
}
