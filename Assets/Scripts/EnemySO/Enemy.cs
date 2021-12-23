using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy Object/Enemy Battle Object")]
public class Enemy : ScriptableObject
{   
    [Header("General")]
    [SerializeField] private int _maxHealth;
    public int maxHealth {get{return _maxHealth;}}
    [SerializeField] private string _enemyName;
    public string enemyName {get{return _enemyName;}}

    [Header("Battle")]
    [SerializeField] private Vector3 _targetArrowOffset;
    public Vector3 targetArrowOffset {get{return _targetArrowOffset;}} 
    [SerializeField] private List<EnemyActions> _actionsList;
    public List<EnemyActions> actionsList {get{return _actionsList;}}
}