using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI floatingTextTMP;

    public void SetText(string txt) 
    {
        floatingTextTMP.text = txt;
    }
}
