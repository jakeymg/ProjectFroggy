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
        owner.southButtonPressed += owner.CancelTargetSelect;
        owner.uiManager.ShowTargetArrow();
        owner.uiManager.ShowEnemyHealthNamePanel();
        //Set Selection Hand position and Selection outline position based on position of currently selected grid object
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
        owner.southButtonPressed -= owner.CancelTargetSelect;
        owner.uiManager.HideTargetArrow();
        owner.uiManager.HideEnemyHealthNamePanel();
    }
}