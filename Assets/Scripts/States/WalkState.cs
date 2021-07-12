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
        Debug.Log("Entering WalkState");
        owner.GetComponent<PlayerAnimationManager>().PlayIdleWalkRunMixer();
    }

    public override void Execute()
    {

    }

    public override void FixedExecute()
    {
        owner.CheckIfGrounded();

        owner.CheckSlopeAngle();

        owner.MovePlayer();
    }

    public override void OnExit()
    {
        Debug.Log("Exiting WalkState");
    }
}