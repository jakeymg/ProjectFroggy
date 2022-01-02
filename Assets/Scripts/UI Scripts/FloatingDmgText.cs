using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class FloatingDmgText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI floatingDmgTextTMP;
    [SerializeField] private GameObject targetObject;

    private void Update() 
    {
        if(!targetObject){}
        else{this.transform.position = Camera.main.WorldToScreenPoint(targetObject.transform.position + new Vector3(0, 1, 0));}
    }

    public void SetDmgText(int amount) 
    {
        floatingDmgTextTMP.text = amount.ToString();
    }

    public void SetTargetObject(GameObject parent)
    {
        targetObject = parent;
    }
}
