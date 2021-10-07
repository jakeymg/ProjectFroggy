using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class UIHealthBarManager : MonoBehaviour
{
    [SerializeField] private GameObject HealthBarDisplay;
    [SerializeField] private GameObject HealthBarCurrentHealth;
    [SerializeField] private GameObject HealthBarMaxHealth;
    [SerializeField] private TextMeshProUGUI HealthBarCurrentHealthText;
    [SerializeField] private TextMeshProUGUI HealthBarMaxHealthText;

    private void Awake() 
    {
        if (HealthBarDisplay == null) { Debug.Log("HealthBarDisplay cannot be found");}
        if (HealthBarCurrentHealth == null) { Debug.Log("HealthBarCurrentHealth cannot be found");}
        if (HealthBarMaxHealth == null) { Debug.Log("HealthBarMaxHealth cannot be found");}

        HealthBarCurrentHealthText = HealthBarCurrentHealth.GetComponent<TextMeshProUGUI>();
        HealthBarMaxHealthText = HealthBarMaxHealth.GetComponent<TextMeshProUGUI>();
    }
}
