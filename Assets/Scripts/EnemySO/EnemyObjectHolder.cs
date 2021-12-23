using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectHolder : MonoBehaviour
{
    [SerializeField] private Enemy _enemySO;
    public Enemy enemySO {get{return _enemySO;} private set{_enemySO = value;}}
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
        _enemySO.SetFirstQueuedActionID();
        _enemySO.SetCurrentQueuedAction();
        
        _maxHealth = _enemySO.maxHealth;
        _currentHealth = _enemySO.currentHealth;
        _enemyName = _enemySO.enemyName;
        _targetArrowOffset = _enemySO.targetArrowOffset;
        _currentQueuedAction = _enemySO.currentQueuedAction;
    }
}
