using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class BattleActionMenuState : State
{
    BattleManager owner;
    public BattleActionMenuState(BattleManager owner) { this.owner = owner;}
    
    public override void OnEnter()
    {
        owner.eastButtonPressed += owner.ChooseBattleAction;

        owner.gameReferenceManager.uiManager.ShowPlayerBattleActionMenu();

        owner.gameReferenceManager.player.ChangeToChooseBattleAction();

        owner.gameReferenceManager.battleCamera.ReturnToDefaultPosition();
        owner.gameReferenceManager.battleCamera.ReturnToDefaultFieldOfView();

    }

    public override void Execute()
    {

    }

    public override void FixedExecute()
    {
        owner.CheckDirectionInput();
        owner.CheckTimeBeforeNextAction();
        owner.CycleBattleMenu();
    }

    public override void OnExit()
    {
        owner.eastButtonPressed -= owner.ChooseBattleAction;
        
        owner.gameReferenceManager.uiManager.HidePlayerBattleActionMenu();
    }
}