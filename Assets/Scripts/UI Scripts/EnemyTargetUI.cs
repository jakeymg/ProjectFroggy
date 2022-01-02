using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class EnemyTargetUI : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private Vector3 posOffset;

    [Header("Enemy Health Name Panel")]
    [SerializeField] private GameObject _enemyHealthNamePanel;
    [SerializeField] private CanvasGroup _enemyHealthNamePanelCG;
    [SerializeField] private TextMeshProUGUI _enemyNameTMP;
    [SerializeField] private TextMeshProUGUI _enemyCurrentHealthTMP;
    [SerializeField] private UnityEngine.UI.Image _enemyCurrentHealthIMG;

    private void Update() 
    {
        if(!targetObject){}
        else{this.transform.position = Camera.main.WorldToScreenPoint(targetObject.transform.position + posOffset);}
    }

    public void SetTargetObject(GameObject parent, Vector3 positionOffset)
    {
        targetObject = parent;
        posOffset = positionOffset;
    }

    public void ChangeEnemyHealthPanelDisplayStats(string enemyName, int currentHealth, int maxHealth)
    {
        _enemyNameTMP.text = enemyName;
        _enemyCurrentHealthTMP.text = currentHealth.ToString();

        float newFillAmount = (float)currentHealth / (float)maxHealth;
        _enemyCurrentHealthIMG.fillAmount = newFillAmount;
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
