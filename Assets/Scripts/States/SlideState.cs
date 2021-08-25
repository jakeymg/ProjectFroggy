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
        
        owner.MovePlayer(0.5f);
        owner.SlidePlayer();
    }

    public override void OnExit()
    {
        Debug.Log("Exiting SlideState");
    }
}