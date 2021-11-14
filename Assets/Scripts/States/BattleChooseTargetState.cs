using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class BattleChooseTargetState : State
{
    BattleManager owner;
    public BattleChooseTargetState(BattleManager owner) { this.owner = owner;}
    
    public override void OnEnter()
    {

    }

    public override void Execute()
    {

    }

    public override void FixedExecute()
    {
        owner.CheckDirectionInput();
        owner.CheckTimeBeforeNextAction();
        owner.CycleTarget();
    }

    public override void OnExit()
    {
        
    }
}