using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Action", menuName = "Enemy Action/Enemy Action")]
public class EnemyActions : ScriptableObject
{
    [SerializeField] private float _percentToHit;
    [SerializeField] private int _damadgeOnHit;

    public virtual void DoAction()
    {

    }
}
