using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class WalkState : State
{
    Player owner;
    public WalkState(Player owner) { this.owner = owner;}

    public override void OnEnter()
    {
        owner.animationManager.PlayIdleWalkRunMixer();
    }

    public override void Execute()
    {

    }

    public override void FixedExecute()
    {
        owner.CheckIfGrounded();
        owner.CheckSlopeAngle();        
        owner.ShouldPlayerSlideOrFall();

        owner.MovePlayer();
        owner.ApplyGravity();
    }

    public override void OnExit()
    {
    }
}