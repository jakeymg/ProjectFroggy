using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class IdleState : State
{
    GameObject owner;
    public IdleState(GameObject owner) { this.owner = owner;}

    public override void OnEnter()
    {
        Debug.Log("Entering IdleState");
    }

    public override void Execute()
    {
        Debug.Log("Current state is IdleState");
    }

    public override void OnExit()
    {
        Debug.Log("Exiting IdleState");
    }
}