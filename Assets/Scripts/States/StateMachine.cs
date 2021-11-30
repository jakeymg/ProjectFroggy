using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected State _currentState;
    public State currentState { get => _currentState; set => currentState = _currentState;}

    [SerializeField] private UIManager UIManager;

    public void ChangeState(State newState)
    {
        if (_currentState != null)
        {
            if (newState.GetType().ToString() != _currentState.GetType().ToString())
            {
                _currentState.OnExit();
                newState.OnEnter();
                _currentState = newState;
            }
        }
    }

    public void Update() 
    {
        if (_currentState != null)
        {
            _currentState.Execute();
        }
    }
    
    public void FixedUpdate() 
    {
        if (_currentState != null)
        {
            _currentState.FixedExecute();
        }
    }

    public void InitialiseStateMachine(State firstState)
    {
        firstState.OnEnter();
        _currentState = firstState;
    }

    public void ChangeBattleManagerStateUI(State stateName)
    {
        UIManager.ChangeBattleManagerStateUI(stateName.GetType().ToString());
    }

    public void ChangeCurrentPlayerStateUI(State stateName)
    {
        UIManager.ChangeCurrentPlayerStateUI(stateName.GetType().ToString());
    }
}
