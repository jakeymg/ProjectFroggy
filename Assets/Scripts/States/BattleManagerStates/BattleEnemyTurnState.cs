using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class BattleEnemyTurnState : State
{
    BattleManager owner;
    public BattleEnemyTurnState(BattleManager owner) { this.owner = owner;}
    
    public override void OnEnter()
    {
        owner.PerformEnemyActions();
    }

    public override void Execute()
    {

    }

    public override void FixedExecute()
    {
        
    }

    public override void OnExit()
    {
        
    }
}