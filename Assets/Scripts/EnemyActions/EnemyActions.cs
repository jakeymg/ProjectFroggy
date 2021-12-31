using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Action", menuName = "Enemy Action/Enemy Action")]
public class EnemyActions : ScriptableObject
{
    [SerializeField] private float _percentToHit;
    [SerializeField] private int _damadgeOnHit;

    public void DoAction(GameObject target)
    {
        bool hitCheck = DoesActionHit();

        if (hitCheck)
        {
            Debug.Log(target + " takes " + _damadgeOnHit + " damadge");
        }
    }

    bool DoesActionHit()
    {
        float hitCheck = Random.Range(0.01f, 1f);

        if (hitCheck <= _percentToHit)
        {
            Debug.Log("Enemy successfully hit target");
            return true;
        }
        else
        {
            Debug.Log("Enemy Missed Attack");
            return false;
        }
    }
}
