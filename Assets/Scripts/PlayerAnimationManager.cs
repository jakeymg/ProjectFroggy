using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] private AnimancerComponent _Animancer;

    [SerializeField] private AnimationClip[] _SittingIdle;
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
        StopAllCoroutines();
        StartCoroutine(CoroutineSittingAnimation());
    }

    private IEnumerator CoroutineSittingAnimation()
    {
        for (int i = 0; i < _SittingIdle.Length; i++)
        {
            var state = Play(i);
            yield return state;
        }
        //_Animancer.Play(_SittingIdle[1], 0.25f);

        StartCoroutine(CoroutineSittingIdle());
    }

    private AnimancerState Play(int index)
    {
        var animation = _SittingIdle[index];
        return _Animancer.Play(animation);
    }

    private IEnumerator CoroutineSittingIdle()
    {
        yield return new WaitForSeconds(Random.Range(3.0f, 15.0f));
        yield return _Animancer.Play(_SittingTwo, 0.25f);
        _Animancer.Play(_SittingIdle[1], 0.25f);

        StartCoroutine(CoroutineSittingIdle());
    }
}
