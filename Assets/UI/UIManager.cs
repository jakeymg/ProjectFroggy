using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private GameObject actionPromptPanel;
    [SerializeField] private PromptTrigger recentTriggeredObject;
    [SerializeField] private TextMeshProUGUI currentStateText;
    [SerializeField] private GameObject dialougePanel;
    [SerializeField] private TextMeshProUGUI dialougeTextArea;
    [SerializeField] private DialougeTypewriterEffect dialougeTypewriterEffect;
    [SerializeField] private bool _progressDialougeBool = false;
    [SerializeField] private Player _player;

    public void ChangeCurrentStateText(string currentState)
    {
        currentStateText.text = currentState;
    }

    public void ShowActionPrompt(string actionPromptText)
    {
        actionPromptPanel.SetActive(true);
        FadeInPanel(actionPromptPanel, -370);

        actionPromptPanel.GetComponentInChildren<TextMeshProUGUI>().text = actionPromptText; 
        
    }

    public void HideActionPrompt()
    {        
        FadeOutPanel(actionPromptPanel, -390);
        actionPromptPanel.GetComponentInChildren<TextMeshProUGUI>().text = string.Empty;
        actionPromptPanel.SetActive(true);
    }

    public void OpenDialougePanel(SignDialougeObject signDialougeObject, PromptTrigger something)
    {
        actionPromptPanel.SetActive(false);
        FadeInPanel(dialougePanel, -290);
        recentTriggeredObject = something;
        StartCoroutine(StepThroughDialouge(signDialougeObject));     
    }

    private IEnumerator StepThroughDialouge (SignDialougeObject signDialougeObject)
    {
        foreach (string text in signDialougeObject.Text)
        {
            yield return dialougeTypewriterEffect.Run(text, dialougeTextArea);
            //Wait for dialouge to finish printing before letting player trigger next line
            _player.mainButtonPressed += ProgressDialouge;
            yield return new WaitUntil(() => _progressDialougeBool);
            _progressDialougeBool = false;
        }

        CloseDialougePanel(recentTriggeredObject);
    }

    private void ProgressDialouge()
    {
        _player.mainButtonPressed -= ProgressDialouge;
        _progressDialougeBool = true;
    }

    public void CloseDialougePanel(PromptTrigger recentTriggeredObject)
    {
        FadeOutPanel(dialougePanel, -310);
        dialougeTextArea.text = string.Empty;
        actionPromptPanel.SetActive(true);
        recentTriggeredObject.EnableDialougeTrigger();
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
}
