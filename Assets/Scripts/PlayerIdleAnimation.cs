using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class PlayerIdleAnimation : MonoBehaviour
{
    [SerializeField] private AnimancerComponent _Animancer;

    [SerializeField] private AnimationClip _Idle;
    private void OnEnable() 
    {
        _Animancer.Play(_Idle);
    }
}
