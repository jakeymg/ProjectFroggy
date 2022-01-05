using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class SitState : State
{
    Player owner;
    public SitState(Player owner) { this.owner = owner;}

    public override void OnEnter()
    {
        owner.animationManager.PlaySittingAnimation();
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
        owner.GetComponent<PlayerAnimationManager>().StopAllCoroutines();
    }
}