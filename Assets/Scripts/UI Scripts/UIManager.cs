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
    [SerializeField] private GameObject _battleManager;

    [Header("Prompts")]
    [SerializeField] private GameObject actionPromptPanel;
    [SerializeField] private PromptTrigger recentTriggeredObject;

    [Header("Debugging")]
    [SerializeField] private TextMeshProUGUI currentPlayerStateText;
    [SerializeField] private TextMeshProUGUI currentBattleManagerStateText;

    [Header("Dialouge")]
    [SerializeField] private GameObject dialougePanel;
    [SerializeField] private TextMeshProUGUI dialougeTextArea;
    [SerializeField] private DialougeTypewriterEffect dialougeTypewriterEffect;
    [SerializeField] private bool _progressDialougeBool = false;
    [SerializeField] private bool _dialougeIsActive = false;

    [Header("HealthBar")]
    [SerializeField] private GameObject UIHealthBarManager;

    [Header("SelectionHand")]
    [SerializeField] private GameObject selectionHandObject;

    [Header("Battle Actions")]
    [SerializeField] private GameObject playerBattleActionPanel;
    [SerializeField] private TextMeshProUGUI currentPlayerBattleActionText;
    [SerializeField] private GameObject chooseTargetArrow;
    [SerializeField] private Vector3 targetArrowOffset;

    [Header("Enemy Health Name Panel")]
    [SerializeField] private GameObject _enemyHealthNamePanel;
    [SerializeField] private CanvasGroup _enemyHealthNamePanelCG;
    [SerializeField] private TextMeshProUGUI _enemyNameTMP;
    [SerializeField] private TextMeshProUGUI _enemyCurrentHealthTMP;
    [SerializeField] private UnityEngine.UI.Image _enemyCurrentHealthIMG;

    [Header("Sticker Battle Menu")]
    [SerializeField] private GameObject stickerSelectPanel;
    [SerializeField] private GameObject _stickerGridAreaGameObject;
    [SerializeField] private StickerGridArea _stickerGridArea;
    public StickerGridArea stickerGridArea {get{ return _stickerGridArea;}}

    private void Start() 
    {
        _stickerGridArea = _stickerGridAreaGameObject.GetComponent<StickerGridArea>();
        _enemyHealthNamePanelCG = _enemyHealthNamePanel.GetComponent<CanvasGroup>();
    }

    public void ChangeCurrentPlayerStateUI(string currentPlayerState)
    {
        currentPlayerStateText.text = currentPlayerState;
    }

    public void ChangeBattleManagerStateUI(string currentBattleManagerState)
    {
        currentBattleManagerStateText.text = currentBattleManagerState;
    }

    public void ChangePlayerBattleActionText(string newString)
    {
        currentPlayerBattleActionText.text = newString;
    }

    public void ShowPlayerBattleActionMenu()
    {
        //playerBattleActionPanel.SetActive(true);
        LeanTween.alphaCanvas(playerBattleActionPanel.GetComponent<CanvasGroup>(), 1f, 0.2f);
    }

    public void HidePlayerBattleActionMenu()
    {
        //playerBattleActionPanel.SetActive(false);
        LeanTween.alphaCanvas(playerBattleActionPanel.GetComponent<CanvasGroup>(), 0f, 0.2f);
    }

    public void ShowStickerSelectPanel()
    {
        LeanTween.alphaCanvas(stickerSelectPanel.GetComponent<CanvasGroup>(), 1f, 0.2f);
    }

    public void HideStickerSelectPanel()
    {
        LeanTween.alphaCanvas(stickerSelectPanel.GetComponent<CanvasGroup>(), 0f, 0.2f);
    }

    public void ChangeSelectedStickerUI()
    {
        Vector3 currentGridObjPos = stickerGridArea.FetchCurrentGridObjectPosition();
        Vector3 currentGridObjPosOffset = stickerGridArea.FetchCurrentGridObjectPositionOffset();

        ChangeSelectionHandPosition(currentGridObjPos, currentGridObjPosOffset);
        stickerGridArea.ChangeCurrentSelectedOutlinePosition(currentGridObjPos);
    }

    public void ChangeTargetArrowPosition(Vector3 newTargetPosition)
    {
        Camera cam = Camera.main;
        chooseTargetArrow.transform.position = cam.WorldToScreenPoint(newTargetPosition + targetArrowOffset);
    }

    public void ShowTargetArrow()
    {
        //chooseTargetArrow.SetActive(true);
        LeanTween.alphaCanvas(chooseTargetArrow.GetComponent<CanvasGroup>(), 1f, 0.2f);
    }

    public void HideTargetArrow()
    {
        //chooseTargetArrow.SetActive(false);
        LeanTween.alphaCanvas(chooseTargetArrow.GetComponent<CanvasGroup>(), 0f, 0.2f);
    }

    public void ChangeEnemyHealthNamePanelPosition()
    {
        _enemyHealthNamePanel.transform.position = chooseTargetArrow.transform.position + new Vector3(0, 110, 0);
    }

    public void ShowEnemyHealthNamePanel()
    {
        LeanTween.alphaCanvas(_enemyHealthNamePanelCG, 1f, 0.2f);
    }

    public void HideEnemyHealthNamePanel()
    {
        LeanTween.alphaCanvas(_enemyHealthNamePanelCG, 0f, 0.2f);
    }

    public void SetEnemyHealthPanelDisplayStats(string enemyName, int currentHealth)
    {
        _enemyNameTMP.text = enemyName;
        _enemyCurrentHealthTMP.text = currentHealth.ToString();
    }

    public void ChangeSelectionHandPosition(Vector3 newSelectionPosition, Vector3 offsetAmount)
    {
        selectionHandObject.transform.position = newSelectionPosition + offsetAmount;
    }

    public void ShowSelectionHand()
    {
        LeanTween.alphaCanvas(selectionHandObject.GetComponent<CanvasGroup>(), 1f, 0f);
    }

    public void HideSelectionHand()
    {
        LeanTween.alphaCanvas(selectionHandObject.GetComponent<CanvasGroup>(), 0f, 0f);
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
