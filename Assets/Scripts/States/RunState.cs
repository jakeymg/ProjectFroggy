using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class RunState : State
{
    Player owner;
    public RunState(Player owner) { this.owner = owner;}

    public override void OnEnter()
    {
        owner.GetComponent<PlayerAnimationManager>().PlayIdleWalkRunMixer();
    }

    public override void Execute()
    {
        owner.PlayDustParticle();
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