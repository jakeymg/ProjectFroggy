using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Action", menuName = "Enemy Action/Enemy Action")]
public class EnemyActions : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _hitDescription;
    [SerializeField] private string _missDescription;
    [SerializeField] private float _percentToHit;
    [SerializeField] private int _damadgeOnHit;
    [SerializeField] private GameReferenceManager gameManagerRef;

    public void DoAction(GameObject target, string enemyName)
    {
        if (!gameManagerRef){gameManagerRef = target.GetComponent<Player>().gameReferenceManager;}

        bool hitCheck = DoesActionHit();

        if (hitCheck)
        {
            Debug.Log(enemyName + _hitDescription);
            if (_damadgeOnHit == 0){}
            else {gameManagerRef.uiManager.CreateFloatingDmgText(_damadgeOnHit, target.transform.position, target);}
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
