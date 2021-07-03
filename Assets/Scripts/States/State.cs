using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public virtual void OnEnter()
    {
        Debug.Log("Entering test state");
    }

    public virtual void Execute()
    {
        Debug.Log("Current state is test state");
    }

    public virtual void OnExit()
    {
        Debug.Log("Exiting test state");
    }
}