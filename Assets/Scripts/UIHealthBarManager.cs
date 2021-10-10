using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class UIHealthBarManager : MonoBehaviour
{
    [SerializeField] private GameObject HealthBarDisplay;
    [SerializeField] private GameObject HealthBarCurrentHealth;
    [SerializeField] private GameObject HealthBarMaxHealth;
    [SerializeField] private TextMeshProUGUI HealthBarCurrentHealthText;
    [SerializeField] private TextMeshProUGUI HealthBarMaxHealthText;
    [SerializeField] private UnityEngine.UI.Image _healthBarDisplayImage;

    [SerializeField] private Player Player;
    [SerializeField] private PlayerStats PlayerStats;
    
    private void Awake() 
    {
        if (HealthBarDisplay == null) { Debug.Log("HealthBarDisplay cannot be found");}
        if (HealthBarCurrentHealth == null) { Debug.Log("HealthBarCurrentHealth cannot be found");}
        if (HealthBarMaxHealth == null) { Debug.Log("HealthBarMaxHealth cannot be found");}
        if (Player == null) {Debug.Log("No reference to the player found");}

        HealthBarCurrentHealthText = HealthBarCurrentHealth.GetComponent<TextMeshProUGUI>();
        HealthBarMaxHealthText = HealthBarMaxHealth.GetComponent<TextMeshProUGUI>();
        _healthBarDisplayImage = HealthBarDisplay.GetComponent<UnityEngine.UI.Image>();
        PlayerStats = Player.GetComponent<PlayerStats>();

        HealthBarMaxHealthText.text = ("/" + PlayerStats.maxHealth.ToString()); 
    }

    public void DecreaseHealthButton(int v)
    {
        PlayerStats.DecreasePlayerCurrentHealth(v);
        DecreaseHealthDisplay(PlayerStats.currentHealth);
    }

    private void DecreaseHealthDisplay(int to)
    {
        int maxHealth = PlayerStats.maxHealth;

        float currentFloatValue = _healthBarDisplayImage.fillAmount;
        float newFloatValue = (float)to / (float)maxHealth;;

        HealthBarCurrentHealthText.text = PlayerStats.currentHealth.ToString();

        LeanTween.value(_healthBarDisplayImage.gameObject, HealthBarDisplayFloatCallback, currentFloatValue, newFloatValue, 0.25f);
    }

    public void IncreaseHealthButton(int v)
    {
        PlayerStats.IncreasePlayerCurrentHealth(v);
        IncreaseHealthDisplay(PlayerStats.currentHealth);
    }

    private void IncreaseHealthDisplay(int to)
    {
        int maxHealth = PlayerStats.maxHealth;

        float currentFloatValue = _healthBarDisplayImage.fillAmount;
        float newFloatValue = (float)to / (float)maxHealth;

        HealthBarCurrentHealthText.text = PlayerStats.currentHealth.ToString();

        LeanTween.value(_healthBarDisplayImage.gameObject, HealthBarDisplayFloatCallback, currentFloatValue, newFloatValue, 0.25f);
    }

    private void HealthBarDisplayFloatCallback(float v)
    {
        _healthBarDisplayImage.fillAmount = v;
    }
}
