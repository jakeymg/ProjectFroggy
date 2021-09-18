using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Canvas mainCanvas;
    [SerializeField] private GameObject actionPrompt_Panel;

    [SerializeField] private TextMeshProUGUI currentStateText;
    [SerializeField] private float actionPanelAlpha;

    public void ChangeCurrentStateText(string currentState)
    {
        currentStateText.text = currentState;
    }

    public void ShowActionPrompt(string actionPromptText)
    {
        actionPrompt_Panel.GetComponent<CanvasGroup>().alpha = 1f;
        actionPrompt_Panel.SetActive(true);
        
        FadeInPanel(actionPrompt_Panel);
    }

    public void HideActionPrompt()
    {
        actionPrompt_Panel.GetComponent<CanvasGroup>().alpha = 0f;
        actionPrompt_Panel.SetActive(false);

        FadeInPanel(actionPrompt_Panel);
    }

    private void FadeInPanel(GameObject panel)
    {
        float panelAlpha = panel.GetComponent<CanvasGroup>().alpha;

        actionPanelAlpha = panelAlpha;
    }
}
