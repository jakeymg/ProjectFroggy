using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class BattlePerformAttackState : State
{
    BattleManager owner;
    public BattlePerformAttackState(BattleManager owner) { this.owner = owner;}
    
    public override void OnEnter()
    {
        owner.AttackTarget();
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