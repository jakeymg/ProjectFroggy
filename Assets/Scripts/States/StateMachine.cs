using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected State currentState;

    public void ChangeState(State newState)
    {
        if (currentState != null)
        {
            if (newState.GetType().ToString() != currentState.GetType().ToString())
            {
                currentState.OnExit();
                newState.OnEnter();
                currentState = newState; 
            }
        }
    }

    public void Update() 
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }

    public void InitialiseStateMachine(State firstState)
    {
        firstState.OnEnter();
        currentState = firstState;
    }
}
