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
        owner.eastButtonPressed += owner.ChooseTarget;

        //owner.gameReferenceManager.battleCamera.ChangeTargetPosition(owner.gameReferenceManager.battleCamera.gameObject, new Vector3(-1f, 0f, 1f));
        owner.gameReferenceManager.battleCamera.ChangeFieldOfView(16);

        owner.gameReferenceManager.player.ChangeToReadyToAttack();

        owner.CreateTargetEnemyUI();
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
        owner.eastButtonPressed -= owner.ChooseTarget;

        owner.gameReferenceManager.uiManager.DestroyEnemyTargetUI();
    }
}