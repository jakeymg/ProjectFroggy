using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class FallState : State
{
    Player owner;
    public FallState(Player owner) { this.owner = owner;}

    public override void OnEnter()
    {
        Debug.Log("Entering FallState");
        owner.GetComponent<PlayerAnimationManager>().PlayFalling();
    }

    public override void Execute()
    {

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
        Debug.Log("Exiting FallState");
    }
}