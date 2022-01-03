using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private GameReferenceManager _gameReferenceManager;
    [SerializeField] private int _maxHealth;
    public int maxHealth {get{return _maxHealth;}}

    [SerializeField] private int _currentHealth;
    public int currentHealth {get{return _currentHealth;} private set {_currentHealth = value;}}

    [SerializeField] private int _strength;
    public int strength {get{return _strength;} private set {_strength = value;}}

    public void IncreasePlayerCurrentHealth(int v)
    {
        if ((currentHealth + v) >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += v;
        }

        _gameReferenceManager.uiManager.uiHealthBarManager.IncreaseHealthDisplay(currentHealth);
    }

    public void DecreasePlayerCurrentHealth(int v)
    {
        if ((currentHealth - v) <= 0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= v;
        }

        _gameReferenceManager.uiManager.uiHealthBarManager.DecreaseHealthDisplay(currentHealth);
    }

    public void ChangePlayerStrength(int v)
    {
        strength = strength + (v);

        if (strength <= 0)
        {
            strength = 0;
        }
    }

}
