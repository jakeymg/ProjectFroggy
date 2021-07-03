using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] private AnimancerComponent _Animancer;

    [SerializeField] private AnimationClip _Idle;

    public void PlayIdleAnimation()
    {
        _Animancer.Play(_Idle);
    }
}
