using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class IdleState : State
{
    Player owner;
    private StateMachine _stateMachine;
    private float _idleTime = 0f;
    
    public IdleState(Player owner) { this.owner = owner;}

    public override void OnEnter()
    {
        Debug.Log("Entering IdleState");
        _stateMachine = owner.GetComponent<StateMachine>();
        owner.GetComponent<PlayerAnimationManager>().PlayIdleWalkRunMixer();
    }

    public override void Execute()
    {
        _idleTime += Time.deltaTime;
        if(_idleTime >= 30f)
        {
             owner.ChangeToSitting();
        }
    }

    public override void OnExit()
    {
        Debug.Log("Exiting IdleState");
    }
}