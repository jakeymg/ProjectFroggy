using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class ChooseSticker : State
{
    Player owner;    
    public ChooseSticker(Player owner) { this.owner = owner;}

    public override void OnEnter()
    {
        owner.animationManager.PlayChooseSticker();
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