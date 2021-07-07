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
        Debug.Log("Entering RunState");
    }

    public override void Execute()
    {
       owner.GetComponent<PlayerAnimationManager>().PlayRunAnimation();
    }

    public override void OnExit()
    {
        Debug.Log("Exiting RunState");
    }
}