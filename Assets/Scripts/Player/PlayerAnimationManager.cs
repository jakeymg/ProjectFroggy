using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] private AnimancerComponent _Animancer;

    [SerializeField] private AnimationClip[] _SittingIdle;
    [SerializeField] private AnimationClip _SittingTwo;
    [SerializeField] private AnimationClip _Sliding;
    [SerializeField] private AnimationClip _Falling;
    [SerializeField] private LinearMixerTransition _IdleWalkRunMixer;
    private LinearMixerState _IdleWalkRunState;
    public float IdleWalkRunMixerValue {get => _IdleWalkRunState.Parameter; set => _IdleWalkRunState.Parameter = value;}

    [Header("Battle Animations")]
    [SerializeField] private AnimationClip _thinking;
    [SerializeField] private AnimationClip _readyToAttack;
    [SerializeField] private AnimationClip _attackBasic;
    [SerializeField] private AnimationClip _chooseSticker;


    public void PlayIdleWalkRunMixer()
    {
        _Animancer.Play(_IdleWalkRunMixer);
        _IdleWalkRunState = _IdleWalkRunMixer.Transition.State;
    }

    public void PlaySliding()
    {
        _Animancer.Play(_Sliding, 0.1f);
    }

    public void PlayFalling()
    {
        _Animancer.Play(_Falling, 0.1f);
    }

    public void PlayThinking()
    {
        _Animancer.Play(_thinking, 0.1f);
    }

    public void PlayReadyToAttack()
    {
        _Animancer.Play(_readyToAttack, 0.1f);
    }

    public IEnumerator PlayAttackBasic()
    {
        yield return _Animancer.Play(_attackBasic, 0.1f);
        _Animancer.Play(_readyToAttack, 0.1f);
    }

    public void PlayChooseSticker()
    {
        _Animancer.Play(_chooseSticker, 0.1f);
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
