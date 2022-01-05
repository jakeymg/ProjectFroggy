using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class BattleChooseStickerState : State
{
    BattleManager owner;

    public BattleChooseStickerState(BattleManager owner) { this.owner = owner;}
    
    public override void OnEnter()
    {
        owner.southButtonPressed += owner.CancelChooseSticker;
       
        owner.gameReferenceManager.uiManager.ChangeSelectedStickerUI();
        //Show Sticker Page Menu and Selection Hand objects on the UI
        owner.gameReferenceManager.uiManager.ShowStickerSelectPanel();
        owner.gameReferenceManager.uiManager.ShowSelectionHand();

        owner.gameReferenceManager.battleCamera.ChangeFieldOfView(16);

        owner.gameReferenceManager.player.ChangeToChooseSticker();
    }

    public override void Execute()
    {

    }

    public override void FixedExecute()
    {
        owner.CheckDirectionInput();
        owner.CheckTimeBeforeNextAction();
        owner.CycleSelectedSticker();
    }

    public override void OnExit()
    {
        owner.southButtonPressed -= owner.CancelChooseSticker;
        owner.gameReferenceManager.uiManager.HideStickerSelectPanel();
        owner.gameReferenceManager.uiManager.HideSelectionHand();
    }
}