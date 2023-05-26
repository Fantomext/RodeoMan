using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] private Gun[] _guns;
    [SerializeField] Gun _currentGun;
    private void Start()
    {
        TakeGunByIndex(0);
    }

    public Gun CurrentGunReturn()
    {
        return _currentGun;
    }

    public void TakeGunByIndex(int gunIndex)
    {
        for (int i = 0; i < _guns.Length; i++)
        {
            if (gunIndex == i)
            {
                _guns[i].Activate();
                _currentGun = _guns[i];
            }
            else
            {
                _guns[i].Deactivate();
            }

        }
    }

    public void AddBullets(int gunIndex, int countBullets)
    {
        _guns[gunIndex].AddBullets(countBullets);
    }
}
