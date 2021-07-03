using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private AnimancerComponent _Animancer;

    [SerializeField] private AnimationClip _Idle;

    // private void OnEnable() 
    // {
    //     _Animancer.Play(_Idle);
    // }

    public void PlayIdleAnimation()
    {
        _Animancer.Play(_Idle);
    }
}
