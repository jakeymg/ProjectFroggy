using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class IdleState : State
{
    Player owner;
    
    public IdleState(Player owner) { this.owner = owner;}

    public override void OnEnter()
    {
        Debug.Log("Entering IdleState");
        owner.GetComponent<PlayerAnimationManager>().PlayIdleWalkRunMixer();
    }

    public override void Execute()
    {
        
    }

    public override void OnExit()
    {
        Debug.Log("Exiting IdleState");
    }
}