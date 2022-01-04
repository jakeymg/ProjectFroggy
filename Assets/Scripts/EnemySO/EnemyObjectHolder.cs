using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectHolder : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private Enemy _enemySO;
    public Enemy enemySO {get{return _enemySO;} private set{_enemySO = value;}}
    [SerializeField] private int _maxHealth;
    public int maxHealth {get{return _maxHealth;} private set{_maxHealth = value;}}
    [SerializeField] private int _currentHealth;
    public int currentHealth {get{return _currentHealth;} private set{_currentHealth = value;}}
    [SerializeField] private string _enemyName;
    public string enemyName {get{return _enemyName;} private set{_enemyName = value;}}
    [SerializeField] private Vector3 _targetArrowOffset;

    [Header("Actions")]
    [SerializeField] private List<EnemyActions> _actionsList;
    [SerializeField] private EnemyActions _currentQueuedAction;
    [SerializeField] private EnemyActions.EnemyActionType actionType;
    [SerializeField] private int _currentQueuedActionID;

    [Header("References")]
    [SerializeField] private EnemyAnimationManager enemyAnimationManagerRef;

    void Start()
    {
        SetScriptableObjectValues();
        enemyAnimationManagerRef = this.gameObject.GetComponent<EnemyAnimationManager>();
        enemyAnimationManagerRef.PlayEnemyBattleIdle();
    }

    private void OnEnable() 
    {
        SetScriptableObjectValues();
        enemyAnimationManagerRef = this.gameObject.GetComponent<EnemyAnimationManager>();
        enemyAnimationManagerRef.PlayEnemyBattleIdle();
    }

    private void FetchActionType()
    {
        actionType = _currentQueuedAction._actionType;
    }

    void SetScriptableObjectValues()
    {
        _actionsList = enemySO.actionsList;

        SetFirstQueuedActionID();
        
        maxHealth = enemySO.maxHealth;
        currentHealth = enemySO.maxHealth;
        enemyName = enemySO.enemyName;
        _targetArrowOffset = enemySO.targetArrowOffset;
    }

    void SetFirstQueuedActionID()
    {
        _currentQueuedActionID = 0;
        _currentQueuedAction = _actionsList[_currentQueuedActionID];
    }

    void SetNextQueuedAction()
    {
        _currentQueuedActionID ++;

        if (_currentQueuedActionID >= _actionsList.Count)
        {
            _currentQueuedActionID = 0;
        }
        else{}

        _currentQueuedAction = _actionsList[_currentQueuedActionID];
    }

    public void DoCurrentQueuedAction(GameObject target)
    {
        FetchActionType();
        _currentQueuedAction.DoAction(target, enemyName);
        PlayAnimation();
        SetNextQueuedAction();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        StartCoroutine(enemyAnimationManagerRef.PlayHurt());

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    private void PlayAnimation()
    {
        switch (actionType)
        {
            case EnemyActions.EnemyActionType.BasicAttack:
                StartCoroutine(enemyAnimationManagerRef.PlayBasicAttack());
                break;
            case EnemyActions.EnemyActionType.SpecialAttack:
                StartCoroutine(enemyAnimationManagerRef.PlaySpecialAction());
                break;
            case EnemyActions.EnemyActionType.Buff:
                break;
            case EnemyActions.EnemyActionType.Debuff:
                break;
            default:
                break;
        }
    }
}
