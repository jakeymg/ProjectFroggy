using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class SlideState : State
{
    Player owner;
    public SlideState(Player owner) { this.owner = owner;}

    public override void OnEnter()
    {
        Debug.Log("Entering SlideState");
        owner.GetComponent<PlayerAnimationManager>().PlaySliding();
    }

    public override void Execute()
    {
        owner.PlayDustParticle();
    }

    public override void FixedExecute()
    {
        owner.CheckIfGrounded();

        owner.CheckSlopeAngle();

        owner.MovePlayer();
        
        owner.SlidePlayer();
    }

    public override void OnExit()
    {
        Debug.Log("Exiting SlideState");
    }
}