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
        owner.uiManager.ShowStickerSelectPanel();
        owner.uiManager.ShowSelectionHand();
    }

    public override void Execute()
    {

    }

    public override void FixedExecute()
    {
        owner.CheckDirectionInput();
        owner.CheckTimeBeforeNextAction();
    }

    public override void OnExit()
    {
        owner.southButtonPressed -= owner.CancelChooseSticker;
        owner.uiManager.HideStickerSelectPanel();
        owner.uiManager.HideSelectionHand();
    }
}