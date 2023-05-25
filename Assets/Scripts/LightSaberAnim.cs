using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaberAnim : MonoBehaviour
{
    private const string IS_HITMELEE = "isHit";
    [SerializeField] Animator _animator;
    [SerializeField] Player _player;

    private void Update()
    {
        _animator.SetBool(IS_HITMELEE, _player.IsHit());
    }

}
