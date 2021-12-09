using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy Object/Enemy Battle Object")]
public class Enemy : ScriptableObject
{   
    [Header("General")]
    [SerializeField] private int _maxHealth;
    public int maxHealth {get{return _maxHealth;} private set{_maxHealth = value;}}
    [SerializeField] private int _currentHealth;
    public int currentHealth {get{return _currentHealth;} private set{_currentHealth = value;}}
    [SerializeField] private string _enemyName;
    public string enemyName {get{return _enemyName;} private set{_enemyName = value;}}

    [Header("Battle")]
    [SerializeField] private Vector3 _targetArrowOffset;
    public Vector3 targetArrowOffset {get{return _targetArrowOffset;} private set{_targetArrowOffset = value;}} 
    [SerializeField] private List<EnemyActions> _actionsList;
    [SerializeField] private EnemyActions _currentQueuedAction;
    public EnemyActions currentQueuedAction {get{return _currentQueuedAction;} private set {_currentQueuedAction = value;}}
    [SerializeField] private int _currentQueuedActionID;

    public void SetFirstQueuedActionID()
    {
        _currentQueuedActionID = 0;
    }

    public void SetCurrentQueuedAction()
    {
        _currentQueuedAction = _actionsList[_currentQueuedActionID];

        _currentQueuedActionID ++;

        if (_currentQueuedActionID > _actionsList.Count)
        {
            _currentQueuedActionID = 0;
        }
        else{}
    }

    public void DoCurrentQueuedAction()
    {
        _currentQueuedAction.DoAction();
    }
}