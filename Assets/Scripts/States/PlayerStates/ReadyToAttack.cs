using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class ReadyToAttack : State
{
    Player owner;    
    public ReadyToAttack(Player owner) { this.owner = owner;}

    public override void OnEnter()
    {
        owner.animationManager.PlayReadyToAttack();

        LeanTween.rotateY(owner.gameObject, 0f, 0.2f);
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