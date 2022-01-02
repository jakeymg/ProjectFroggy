using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI floatingTextTMP;
    [SerializeField] private GameObject targetObject;

    private void Update() 
    {
        if(!targetObject){}
        else{this.transform.position = Camera.main.WorldToScreenPoint(targetObject.transform.position + new Vector3(0, 1, 0));}
    }
    
    public void SetText(string txt) 
    {
        floatingTextTMP.text = txt;
    }

    public void SetTargetObject(GameObject parent)
    {
        targetObject = parent;
    }
}
