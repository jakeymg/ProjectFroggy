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
        Debug.Log("Entering SitState");
        owner.GetComponent<PlayerAnimationManager>().PlaySittingAnimation();
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
        Debug.Log("Exiting SitState");
        owner.GetComponent<PlayerAnimationManager>().StopAllCoroutines();
    }
}