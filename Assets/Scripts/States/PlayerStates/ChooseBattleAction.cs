using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class ChooseBattleAction : State
{
    Player owner;    
    public ChooseBattleAction(Player owner) { this.owner = owner;}

    public override void OnEnter()
    {
        owner.GetComponent<PlayerAnimationManager>().PlayIdleWalkRunMixer();
    }

    public override void Execute()
    {

    }

    public override void FixedExecute()
    {
        owner.CheckIfGrounded();
        owner.CheckSlopeAngle();        
        owner.ShouldPlayerSlideOrFall();

        owner.ApplyGravity();
    }

    public override void OnExit()
    {
    }
}