using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] private AnimancerComponent _Animancer;
    [SerializeField] private AnimationClip _Idle;
    [SerializeField] private AnimationClip _Walk;
    [SerializeField] private AnimationClip _Run;

    public void PlayIdleAnimation()
    {
        _Animancer.Play(_Idle, 0.25f);
    }

    public void PlayWalkAnimation()
    {
        _Animancer.Play(_Walk, 0.25f);
    }

    public void PlayRunAnimation()
    {
        _Animancer.Play(_Run, 0.25f);
    }
}
