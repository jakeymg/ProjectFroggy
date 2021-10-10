using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    public int maxHealth {get{return _maxHealth;}}

    [SerializeField] private int _currentHealth;
    public int currentHealth {get{return _currentHealth;} private set {_currentHealth = value;}}

    public void IncreasePlayerCurrentHealth(int v)
    {
        if ((_currentHealth + v) >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else
        {
            _currentHealth += v;
        }
    }

    public void DecreasePlayerCurrentHealth(int v)
    {
        if ((_currentHealth - v) <= 0)
        {
            _currentHealth = 0;
        }
        else
        {
            _currentHealth -= v;
        }
    }

}
