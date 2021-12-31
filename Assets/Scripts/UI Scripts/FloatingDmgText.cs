using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class FloatingDmgText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI floatingDmgTextTMP;

    public void SetDmgText(int amount) 
    {
        floatingDmgTextTMP.text = amount.ToString();
    }
}
