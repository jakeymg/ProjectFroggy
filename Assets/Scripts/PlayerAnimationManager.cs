using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] private AnimancerComponent _Animancer;
    [SerializeField] private AnimationClip _SittingStart;
    [SerializeField] private AnimationClip _SittingOne;
    [SerializeField] private AnimationClip _SittingTwo;
    [SerializeField] private LinearMixerTransition _IdleWalkRunMixer;
    private LinearMixerState _IdleWalkRunState;
    public float IdleWalkRunMixerValue {get => _IdleWalkRunState.Parameter; set => _IdleWalkRunState.Parameter = value;}

    public void PlayIdleWalkRunMixer()
    {
        _Animancer.Play(_IdleWalkRunMixer);
        _IdleWalkRunState = _IdleWalkRunMixer.Transition.State;
    }

    public void PlaySittingAnimation()
    {
        _Animancer.Play(_SittingStart, 0.25f);
    }
}
