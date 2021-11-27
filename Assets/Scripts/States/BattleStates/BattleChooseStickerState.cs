using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class BattleChooseStickerState : State
{
    BattleManager owner;
    [SerializeField]private Vector3 currentGridObjectPosition;
    [SerializeField]private Vector3 currentGridObjectPositionOffset;

    public BattleChooseStickerState(BattleManager owner) { this.owner = owner;}
    
    public override void OnEnter()
    {
        owner.southButtonPressed += owner.CancelChooseSticker;
       
        //Store starting position and offset for selection hand and selected outline
        currentGridObjectPosition = owner.uiManager.stickerGridArea.FetchCurrentGridObjectPosition();
        currentGridObjectPositionOffset = owner.uiManager.stickerGridArea.FetchCurrentGridObjectPositionOffset();
        
        //Set position of selected hand and selected outline
        owner.uiManager.ChangeSelectionHandPosition(currentGridObjectPosition, currentGridObjectPositionOffset);
        owner.uiManager.stickerGridArea.ChangeCurrentSelectedOutlinePosition(currentGridObjectPosition);

        //Show Sticker Page Menu and Selection Hand objects on the UI
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
        owner.CycleSelectedSticker();
    }

    public override void OnExit()
    {
        owner.southButtonPressed -= owner.CancelChooseSticker;
        owner.uiManager.HideStickerSelectPanel();
        owner.uiManager.HideSelectionHand();
    }
}