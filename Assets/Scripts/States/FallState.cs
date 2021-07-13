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
    }

    public override void Execute()
    {

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
        Debug.Log("Exiting FallState");
    }
}