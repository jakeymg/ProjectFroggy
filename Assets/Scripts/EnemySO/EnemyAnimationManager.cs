using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class EnemyAnimationManager : MonoBehaviour
{
    [SerializeField] private AnimancerComponent _AnimancerComponent;
    [SerializeField] private AnimationClip _idleBattle;
    [SerializeField] private AnimationClip _attackBasic;
    [SerializeField] private AnimationClip _specialAction;
    [SerializeField] private AnimationClip _hurtBasic;

    public void PlayEnemyBattleIdle()
    {
        _AnimancerComponent.Play(_idleBattle, 0.1f);
    }

    public IEnumerator PlayBasicAttack()
    {
        yield return _AnimancerComponent.Play(_attackBasic, 0.1f);
        _AnimancerComponent.Play(_idleBattle);
    }

    public IEnumerator PlaySpecialAction()
    {
        yield return _AnimancerComponent.Play(_specialAction, 0.1f);
        _AnimancerComponent.Play(_idleBattle);
    }

    public IEnumerator PlayHurt()
    {
        yield return _AnimancerComponent.Play(_hurtBasic, 0.1f);
        _AnimancerComponent.Play(_idleBattle);
    }

}
