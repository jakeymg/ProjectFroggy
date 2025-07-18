using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class ChooseBattleAction : State
{
    Player owner;    
    public ChooseBattleAction(Player owner) { this.owner = owner;}

    public override void OnEnter()
    {
        owner.animationManager.PlayThinking();
        
        LeanTween.rotateY(owner.gameObject, 110f, 0.2f);
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