using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public abstract class BattleActionMenuState : State
{
    Player owner;
    public BattleActionMenuState(Player owner) { this.owner = owner;}
    
    public override void OnEnter()
    {
        Debug.Log("Entering BattleActionMenuState state");
    }

    public override void Execute()
    {
        Debug.Log("Current state is BattleActionMenuState state");
    }

    public override void FixedExecute()
    {

    }

    public override void OnExit()
    {
        Debug.Log("Exiting BattleActionMenuState state");
    }
}