using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Action", menuName = "Enemy Action/Enemy Action")]
public class EnemyActions : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] public enum EnemyActionType{
        BasicAttack,
        SpecialAttack,
        Buff,
        Debuff,
    }
    [SerializeField] public EnemyActionType _actionType;
    [SerializeField] private string _hitDescription;
    [SerializeField] private string _missDescription;
    [SerializeField] private float _percentToHit;
    [SerializeField] private int _damadgeOnHit;
    [SerializeField] private GameReferenceManager gameManagerRef;

    public void DoAction(GameObject target, string enemyName)
    {
        if (!gameManagerRef){gameManagerRef = target.GetComponent<Player>().gameReferenceManager;}

        switch (_actionType)
        {
            case EnemyActionType.BasicAttack:
                BasicAttack(target, enemyName);
                break;
            case EnemyActionType.SpecialAttack:
                SpecialAttack(target, enemyName);
                break;
            case EnemyActionType.Buff:
                break;
            case EnemyActionType.Debuff:
                break;
            default:
                break;
        }
    }

    private void BasicAttack(GameObject target, string enemyName)
    {
        bool hitCheck = DoesActionHit();

        if (hitCheck)
        {
            Debug.Log(enemyName + _hitDescription);
            if (_damadgeOnHit == 0){}
            else 
            {
                gameManagerRef.uiManager.CreateFloatingDmgText(_damadgeOnHit, target.transform.position, target);
                gameManagerRef.playerStats.DecreasePlayerCurrentHealth(_damadgeOnHit);
            }
        }
        else if (!hitCheck)
        {
            Debug.Log(enemyName + _missDescription);
            gameManagerRef.uiManager.CreateFloatingText("MISS", target.transform.position, target);
        }
    }

    private void SpecialAttack(GameObject target, string enemyName)
    {
        bool hitCheck = DoesActionHit();

        if (hitCheck)
        {
            Debug.Log(enemyName + _hitDescription);
            if (_damadgeOnHit == 0){}
            else 
            {
                gameManagerRef.uiManager.CreateFloatingDmgText(_damadgeOnHit, target.transform.position, target);
                gameManagerRef.playerStats.DecreasePlayerCurrentHealth(_damadgeOnHit);
            }
        }
        else if (!hitCheck)
        {
            Debug.Log(enemyName + _missDescription);
            gameManagerRef.uiManager.CreateFloatingText("MISS", target.transform.position, target);
        }
    }

    bool DoesActionHit()
    {
        float hitCheck = Random.Range(0.01f, 1f);

        if (hitCheck <= _percentToHit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
