using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private GameObject _player;

    [Header("Prompts")]
    [SerializeField] private GameObject actionPromptPanel;
    [SerializeField] private PromptTrigger recentTriggeredObject;

    [Header("Debugging")]
    [SerializeField] private TextMeshProUGUI currentStateText;

    [Header("Dialouge")]
    [SerializeField] private GameObject dialougePanel;
    [SerializeField] private TextMeshProUGUI dialougeTextArea;
    [SerializeField] private DialougeTypewriterEffect dialougeTypewriterEffect;
    [SerializeField] private bool _progressDialougeBool = false;
    [SerializeField] private bool _dialougeIsActive = false;

    [Header("HealthBar")]
    [SerializeField] private GameObject UIHealthBarManager;

    [Header("Battle Actions")]
    [SerializeField] private GameObject playerBattleActionPanel;
    [SerializeField] private TextMeshProUGUI currentPlayerBattleActionText;

    public void ChangeCurrentStateText(string currentState)
    {
        currentStateText.text = currentState;
    }

    public void ChangePlayerBattleActionText(string newString)
    {
        currentPlayerBattleActionText.text = newString;
    }

    public void ShowActionPrompt(string actionPromptText)
    {
        actionPromptPanel.SetActive(true);
        actionPromptPanel.GetComponentInChildren<TextMeshProUGUI>().text = actionPromptText;
        FadeInPanel(actionPromptPanel, -370);
    }

    public void HideActionPrompt()
    {        
        FadeOutPanel(actionPromptPanel, -390);
        //actionPromptPanel.GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
        actionPromptPanel.SetActive(true);
    }

    public void OpenDialougePanel(SignDialougeObject signDialougeObject, PromptTrigger TriggerObject)
    {
        _dialougeIsActive = true;
        TriggerObject.ChangeToDialougeCamera();
        actionPromptPanel.SetActive(false);
        FadeInPanel(dialougePanel, -290);
        recentTriggeredObject = TriggerObject;
        StartCoroutine(StepThroughDialouge(signDialougeObject));     
    }

    public void CloseDialougePanel(PromptTrigger recentTriggeredObject)
    {
        _dialougeIsActive = false;
        recentTriggeredObject.ChangeToPlayerCamera();
        FadeOutPanel(dialougePanel, -310);
        dialougeTextArea.text = string.Empty;
        actionPromptPanel.SetActive(true);
        recentTriggeredObject.EnableDialougeTrigger();
    }

    private IEnumerator StepThroughDialouge (SignDialougeObject signDialougeObject)
    {
        foreach (string text in signDialougeObject.Text)
        {
            yield return dialougeTypewriterEffect.Run(text, dialougeTextArea);
            //Wait for dialouge to finish printing before letting player trigger next line
            _player.GetComponent<Player>().eastButtonPressed += ProgressDialouge;
            yield return new WaitUntil(() => _progressDialougeBool);
            _progressDialougeBool = false;
        }

        CloseDialougePanel(recentTriggeredObject);
    }

    private void ProgressDialouge()
    {
        _player.GetComponent<Player>().eastButtonPressed -= ProgressDialouge;
        _progressDialougeBool = true;
    }

    private void FadeInPanel(GameObject panel, float posY)
    {
        CanvasGroup panelCanvasGroup = panel.GetComponent<CanvasGroup>();

        LeanTween.moveLocalY(panel, posY, 0.33f);
        LeanTween.alphaCanvas(panelCanvasGroup, 1f, 0.33f);
    }

    private void FadeOutPanel(GameObject panel, float posY)
    {
        CanvasGroup panelCanvasGroup = panel.GetComponent<CanvasGroup>();

        LeanTween.moveLocalY(panel, posY, 0.33f);
        LeanTween.alphaCanvas(panelCanvasGroup, 0f, 0.33f);
    }

    public bool IsDialougeActive()
    {
        return _dialougeIsActive;
    }
}
