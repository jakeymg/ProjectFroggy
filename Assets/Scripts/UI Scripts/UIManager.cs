using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameReferenceManager _gameReferenceManager;
    [SerializeField] private Canvas staticCanvas;
    [SerializeField] private Canvas dynamicCanvas;
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
    [SerializeField] private GameObject floatingDmgTextPrefab;
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private GameObject enemyTargetUIPrefab;

    [Header("Enemy Health Name Panel")]
    [SerializeField] private GameObject enemyTargetUI;
    [SerializeField] private Vector3 posOffset;

    [Header("Sticker Battle Menu")]
    [SerializeField] private GameObject stickerSelectPanel;
    [SerializeField] private GameObject _stickerGridAreaGameObject;
    [SerializeField] private StickerGridArea _stickerGridArea;
    public StickerGridArea stickerGridArea {get{ return _stickerGridArea;}}

    private void Start() 
    {
        _stickerGridArea = _stickerGridAreaGameObject.GetComponent<StickerGridArea>();
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
        LeanTween.alphaCanvas(playerBattleActionPanel.GetComponent<CanvasGroup>(), 1f, 0.1f);
    }

    public void HidePlayerBattleActionMenu()
    {
        //playerBattleActionPanel.SetActive(false);
        LeanTween.alphaCanvas(playerBattleActionPanel.GetComponent<CanvasGroup>(), 0f, 0.1f);
    }

    public void ShowStickerSelectPanel()
    {
        LeanTween.alphaCanvas(stickerSelectPanel.GetComponent<CanvasGroup>(), 1f, 0.1f);
    }

    public void HideStickerSelectPanel()
    {
        LeanTween.alphaCanvas(stickerSelectPanel.GetComponent<CanvasGroup>(), 0f, 0.1f);
    }

    public void ChangeSelectedStickerUI()
    {
        Vector3 currentGridObjPos = stickerGridArea.FetchCurrentGridObjectPosition();
        Vector3 currentGridObjPosOffset = stickerGridArea.FetchCurrentGridObjectPositionOffset();

        ChangeSelectionHandPosition(currentGridObjPos, currentGridObjPosOffset);
        stickerGridArea.ChangeCurrentSelectedOutlinePosition(currentGridObjPos);
    }

    public void CreateEnemyTargetUI(Vector3 position, GameObject parent, string enemyName, int currentHealth, int maxHealth)
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(position + posOffset);

        GameObject newEnemyTargetUI = Instantiate(enemyTargetUIPrefab, pos, Quaternion.identity, staticCanvas.transform);

        enemyTargetUI = newEnemyTargetUI;

        enemyTargetUI.GetComponent<EnemyTargetUI>().ChangeEnemyHealthPanelDisplayStats(enemyName, currentHealth, maxHealth);
        enemyTargetUI.GetComponent<EnemyTargetUI>().SetTargetObject(parent, posOffset);
    }

    public void ChangeEnemyTargetUIPosition(Vector3 position, GameObject parent, string enemyName, int currentHealth, int maxHealth)
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(position + new Vector3(0, 1, 0));

        enemyTargetUI.transform.position = pos;

        enemyTargetUI.GetComponent<EnemyTargetUI>().ChangeEnemyHealthPanelDisplayStats(enemyName, currentHealth, maxHealth);
        enemyTargetUI.GetComponent<EnemyTargetUI>().SetTargetObject(parent, posOffset);
    }

    public void DestroyEnemyTargetUI()
    {
        enemyTargetUI.GetComponent<EnemyTargetUI>().DestroyThis();
    }


    public void CreateFloatingDmgText(int dmgAmount, Vector3 position, GameObject parent)
    {
        Camera cam = Camera.main;

        Vector3 pos = cam.WorldToScreenPoint(position + new Vector3(0, 1, 0));

        GameObject newFloatingDmgText = Instantiate(floatingDmgTextPrefab, pos, Quaternion.identity, staticCanvas.transform);
        newFloatingDmgText.GetComponent<FloatingDmgText>().SetDmgText(dmgAmount);
        newFloatingDmgText.GetComponent<FloatingDmgText>().SetTargetObject(parent);
    }

    public void CreateFloatingText(string txt, Vector3 position, GameObject parent)
    {
        Camera cam = Camera.main;

        Vector3 pos = cam.WorldToScreenPoint(position + new Vector3(0, 1, 0));

        GameObject newFloatingText = Instantiate(floatingTextPrefab, pos, Quaternion.identity, staticCanvas.transform);
        newFloatingText.GetComponent<FloatingText>().SetText(txt);
        newFloatingText.GetComponent<FloatingText>().SetTargetObject(parent);
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
            _gameReferenceManager.player.GetComponent<Player>().eastButtonPressed += ProgressDialouge;
            yield return new WaitUntil(() => _progressDialougeBool);
            _progressDialougeBool = false;
        }

        CloseDialougePanel(recentTriggeredObject);
    }

    private void ProgressDialouge()
    {
        _gameReferenceManager.player.GetComponent<Player>().eastButtonPressed -= ProgressDialouge;
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
