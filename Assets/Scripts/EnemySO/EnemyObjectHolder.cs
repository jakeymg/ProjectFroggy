using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectHolder : MonoBehaviour
{
    [SerializeField] private Enemy EnemyScriptableObject;
    [SerializeField] private int _maxHealth;
    public int maxHealth {get{return _maxHealth;} private set{_maxHealth = value;}}
    [SerializeField] private int _currentHealth;
    public int currentHealth {get{return _currentHealth;} private set{_currentHealth = value;}}
    [SerializeField] private string _enemyName;
    public string enemyName {get{return _enemyName;} private set{_enemyName = value;}}
    [SerializeField] private Vector3 _targetArrowOffset;
    [SerializeField] private EnemyActions _currentQueuedAction;

    void Start()
    {
        SetScriptableObjectValues();
    }

    private void OnEnable() 
    {
        SetScriptableObjectValues();
    }

    void SetScriptableObjectValues()
    {
        EnemyScriptableObject.SetFirstQueuedActionID();
        EnemyScriptableObject.SetCurrentQueuedAction();
        
        _maxHealth = EnemyScriptableObject.maxHealth;
        _currentHealth = EnemyScriptableObject.currentHealth;
        _enemyName = EnemyScriptableObject.enemyName;
        _targetArrowOffset = EnemyScriptableObject.targetArrowOffset;
        _currentQueuedAction = EnemyScriptableObject.currentQueuedAction;
    }
}
