using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy Object/Enemy Battle Object")]
public class Enemy : ScriptableObject
{   
    [Header("General")]
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private string _name;

    [Header("Battle")]
    [SerializeField] private Vector3 _targetArrowOffset; 
    [SerializeField] private List<EnemyActions> _actionsList;
}