using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class BattleManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameReferenceManager _gameReferenceManager;
    public GameReferenceManager gameReferenceManager {get{return _gameReferenceManager;}}
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerControls playerControls;
    [SerializeField] private CinemachineVirtualCamera _mainCamera;
    [SerializeField] private CinemachineFramingTransposer _mainCameraFramingTransposer;
    [SerializeField] private Vector3 _playerDefaultWorldPos;
    
    [Header("Player Battle Actions")]
    [SerializeField] private PlayerBattleAction currentPlayerBattleAction;
    [SerializeField] private PlayerBattleAction defaultPlayerBattleAction;
    [SerializeField] private float moveRepeatDelay;
    [SerializeField] private float timeBeforeNextAction = 0f;
    [SerializeField] private enum PlayerBattleAction {
        Attack,
        Sticker,
        Catch,
        Run,
    }

    [Header("Input Actions")]
    [SerializeField] private Vector2 _directionInput;

    [Header("Enemies")]
    [SerializeField] private int _numberOfEnemies;
    [SerializeField] private GameObject _currentTargetPosition;
    [SerializeField] private EnemyObjectHolder _currentTargetEnemy;
    [SerializeField] private GameObject enemyPositionOne;
    [SerializeField] private EnemyObjectHolder _enemyOne;
    [SerializeField] private GameObject enemyPositionTwo;
    [SerializeField] private EnemyObjectHolder _enemyTwo;
    [SerializeField] private GameObject enemyPositionThree;
    [SerializeField] private EnemyObjectHolder _enemyThree;
    [SerializeField] private List<GameObject> enemyList;
    
    // EVENTS
    public event Action eastButtonPressed;
    public event Action southButtonPressed;
    public event Action westButtonPressed;
    public event Action northButtonPressed;

    private void Awake() 
    {
        _stateMachine = GetComponent<StateMachine>(); if (_stateMachine == null) { Debug.Log("Player State Machine cannot be found");}
        playerInput = GetComponent<PlayerInput>(); if (playerInput == null) { Debug.Log("Player Input cannot be found");}
        _playerDefaultWorldPos = _gameReferenceManager.player.transform.position;

        if (_mainCamera == null) { Debug.Log("Player Follow Camera cannot be found");}
        _mainCameraFramingTransposer = _mainCamera.GetCinemachineComponent<CinemachineFramingTransposer>();

        playerControls = new PlayerControls();
        playerControls.BattleControls.Enable();

        playerControls.BattleControls.EastButton.started += OnEastButton;
        playerControls.BattleControls.EastButton.performed += OnEastButton;
        playerControls.BattleControls.EastButton.canceled += OnEastButton;

        playerControls.BattleControls.SouthButton.started += OnSouthButton;
        playerControls.BattleControls.SouthButton.performed += OnSouthButton;
        playerControls.BattleControls.SouthButton.canceled += OnSouthButton;

        playerControls.BattleControls.WestButton.started += OnWestButton;
        playerControls.BattleControls.WestButton.performed += OnWestButton;
        playerControls.BattleControls.WestButton.canceled += OnWestButton;

        playerControls.BattleControls.NorthButton.started += OnNorthButton;
        playerControls.BattleControls.NorthButton.performed += OnNorthButton;
        playerControls.BattleControls.NorthButton.canceled += OnNorthButton;

    }

    private void Start() 
    {
        SetFirstBattleMenuState();
        SetStartingBattleAction();
        SetEnemyStartingPositions(_numberOfEnemies);
        AddEnemyPrefabs();
        SetFirstTarget(); 
        
    }

    private void FixedUpdate() 
    {
        
    }

    private void SetStartingBattleAction()
    {
        string newPlayerBattleActionString = defaultPlayerBattleAction.ToString();
        _gameReferenceManager.uiManager.ChangePlayerBattleActionText(newPlayerBattleActionString);

    }

    public void SetEnemyStartingPositions(int numberOfEnemies)
    {
        switch(numberOfEnemies)
        {
            case 1:
                enemyPositionOne.SetActive(true);
                enemyPositionTwo.SetActive(false);
                enemyPositionThree.SetActive(false);
                enemyPositionOne.transform.position = new Vector3(0, 1, 4);
                break;
            case 2:
                enemyPositionOne.SetActive(true);
                enemyPositionTwo.SetActive(true);
                enemyPositionThree.SetActive(false);
                enemyPositionOne.transform.position = new Vector3(2, 1, 4);
                enemyPositionTwo.transform.position = new Vector3(-2, 1, 4);
                break;
            case 3:
                enemyPositionOne.SetActive(true);
                enemyPositionTwo.SetActive(true);
                enemyPositionThree.SetActive(true);
                enemyPositionOne.transform.position = new Vector3(0, 1, 4);
                enemyPositionTwo.transform.position = new Vector3(3, 1, 4);
                enemyPositionThree.transform.position = new Vector3(-3, 1, 4);
                break;
            default:
                Debug.Log("Something is wrong when setting enemy starting positions");
                break;
        }
    }

    private void AddEnemyPrefabs()
    {
        switch(_numberOfEnemies)
        {
            case 1:
                Instantiate(enemyList[0], enemyPositionOne.transform.position, enemyPositionOne.transform.rotation, enemyPositionOne.transform);
                _enemyOne = enemyPositionOne.GetComponentInChildren<EnemyObjectHolder>();
                break;
            case 2:
                Instantiate(enemyList[0], enemyPositionOne.transform.position, enemyPositionOne.transform.rotation, enemyPositionOne.transform);
                Instantiate(enemyList[1], enemyPositionTwo.transform.position, enemyPositionTwo.transform.rotation, enemyPositionTwo.transform);
                _enemyOne = enemyPositionOne.GetComponentInChildren<EnemyObjectHolder>();
                _enemyTwo = enemyPositionTwo.GetComponentInChildren<EnemyObjectHolder>();
                break;
            case 3:
                Instantiate(enemyList[0], enemyPositionOne.transform.position, enemyPositionOne.transform.rotation, enemyPositionOne.transform);
                Instantiate(enemyList[1], enemyPositionTwo.transform.position, enemyPositionTwo.transform.rotation, enemyPositionTwo.transform);
                Instantiate(enemyList[2], enemyPositionThree.transform.position, enemyPositionThree.transform.rotation, enemyPositionThree.transform);
                _enemyOne = enemyPositionOne.GetComponentInChildren<EnemyObjectHolder>();
                _enemyTwo = enemyPositionTwo.GetComponentInChildren<EnemyObjectHolder>();
                _enemyThree = enemyPositionThree.GetComponentInChildren<EnemyObjectHolder>();
                break;
            default:
                break;
        }
    }

    public void AssignEnemyToEnemyList(GameObject Enemy)
    {
        enemyList.Add(Enemy);
    }

    private void SetFirstTarget()
    {  
        _currentTargetPosition = enemyPositionOne;
        _currentTargetEnemy = _enemyOne;
    }

    public void SetFirstBattleMenuState()
    {
        State thisState = new BattleActionMenuState(this);
        _stateMachine.InitialiseStateMachine(thisState);
        _stateMachine.ChangeBattleManagerStateUI(thisState);
    }

    public void ChangeToBattleActionMenuState()
    {
        State thisState = new BattleActionMenuState(this);
        _stateMachine.ChangeState(thisState);
        _stateMachine.ChangeBattleManagerStateUI(thisState);
    }

    public void ChangeToChooseTargetState()
    {
        State thisState = new BattleChooseTargetState(this);
        _stateMachine.ChangeState(thisState);
        _stateMachine.ChangeBattleManagerStateUI(thisState);
    }

    public void ChangeToChooseStickerState()
    {
        State thisState = new BattleChooseStickerState(this);
        _stateMachine.ChangeState(thisState);
        _stateMachine.ChangeBattleManagerStateUI(thisState);
    }

    public void ChangeToPerformAttackState()
    {
        State thisState = new BattlePerformAttackState(this);
        _stateMachine.ChangeState(thisState);
        _stateMachine.ChangeBattleManagerStateUI(thisState);
    }

    public void ChangeToEnemyTurnState()
    {
        State thisState = new BattleEnemyTurnState(this);
        _stateMachine.ChangeState(thisState);
        _stateMachine.ChangeBattleManagerStateUI(thisState);
    }

    public void CheckDirectionInput()
    {
        _directionInput = playerControls.BattleControls.Move.ReadValue<Vector2>();
    }

    public void CheckTimeBeforeNextAction()
    {
        if (timeBeforeNextAction > 0f)
        {
            timeBeforeNextAction -= Time.fixedDeltaTime;
        }
        else
        {
            timeBeforeNextAction = 0f;
        }
    }

    public void CycleBattleMenu()
    {
        if (timeBeforeNextAction != 0f)
        {
            return;
        }
        else
        {
            if (_directionInput.x > 0f)
            {
                CycleNextPlayerBattleAction();
            }
            else if (_directionInput.x < 0f)
            {
                CyclePreviousPlayerBattleAction();
            }
        }
    }

    private void CycleNextPlayerBattleAction()
    {
        switch(currentPlayerBattleAction)
        {
            case PlayerBattleAction.Attack:
                currentPlayerBattleAction = PlayerBattleAction.Sticker;
                break;
            case PlayerBattleAction.Sticker:
                currentPlayerBattleAction = PlayerBattleAction.Catch;
                break;
            case PlayerBattleAction.Catch:
                currentPlayerBattleAction = PlayerBattleAction.Run;
                break;
            case PlayerBattleAction.Run:
                currentPlayerBattleAction = PlayerBattleAction.Attack;
                break;
            default:
                Debug.Log("Something is wrong with the Player Battle Action Menu");
                break;
        }

        string newPlayerBattleActionString = currentPlayerBattleAction.ToString();
        _gameReferenceManager.uiManager.ChangePlayerBattleActionText(newPlayerBattleActionString);

        timeBeforeNextAction = moveRepeatDelay;
    }

    private void CyclePreviousPlayerBattleAction()
    {
        switch(currentPlayerBattleAction)
        {
            case PlayerBattleAction.Attack:
                currentPlayerBattleAction = PlayerBattleAction.Run;
                break;
            case PlayerBattleAction.Sticker:
                currentPlayerBattleAction = PlayerBattleAction.Attack;
                break;
            case PlayerBattleAction.Catch:
                currentPlayerBattleAction = PlayerBattleAction.Sticker;
                break;
            case PlayerBattleAction.Run:
                currentPlayerBattleAction = PlayerBattleAction.Catch;
                break;
            default:
                Debug.Log("Something is wrong with the Player Battle Action Menu");
                break;
        }

        string newPlayerBattleActionString = currentPlayerBattleAction.ToString();
        _gameReferenceManager.uiManager.ChangePlayerBattleActionText(newPlayerBattleActionString);

        timeBeforeNextAction = moveRepeatDelay;
    }

    public void ChooseBattleAction()
    {
        if (timeBeforeNextAction != 0f)
        {
            return;
        }

        switch(currentPlayerBattleAction)
        {
            case PlayerBattleAction.Attack:
                ChangeToChooseTargetState();
                break;
            case PlayerBattleAction.Catch:
                break;
            case PlayerBattleAction.Sticker:
                ChangeToChooseStickerState();
                break;
            case PlayerBattleAction.Run:
                break;
            default:
                Debug.Log("Something is wrong with the Choose Battle Action method");
                break;
        }

        timeBeforeNextAction = moveRepeatDelay;
    }

    public void CycleTarget()
    {
        if (timeBeforeNextAction != 0f)
        {
            return;
        }
        else
        {
            if (_directionInput.x > 0f)
            {
                CycleNextTarget();
            }
            else if (_directionInput.x < 0f)
            {
                CyclePreviousTarget();
            }
        }
    }

    private void CycleNextTarget()
    {
        switch(_numberOfEnemies)
        {
            case 1:
                break;
            case 2:
                if (_currentTargetPosition == enemyPositionOne){
                    _currentTargetPosition = enemyPositionTwo;
                    _currentTargetEnemy = _enemyTwo;
                    UpdateTargetEnemyUI();
                }
                else if (_currentTargetPosition == enemyPositionTwo){
                    _currentTargetPosition = enemyPositionOne;
                    _currentTargetEnemy = _enemyOne;
                    UpdateTargetEnemyUI();
                }
                break;
            case 3:
                if (_currentTargetPosition == enemyPositionOne){
                    _currentTargetPosition = enemyPositionTwo;
                    _currentTargetEnemy = _enemyTwo;
                    UpdateTargetEnemyUI();
                }
                else if (_currentTargetPosition == enemyPositionTwo){
                    _currentTargetPosition = enemyPositionThree;
                    _currentTargetEnemy = _enemyThree;
                    UpdateTargetEnemyUI();
                }
                else if (_currentTargetPosition == enemyPositionThree){
                    _currentTargetPosition = enemyPositionOne;
                    _currentTargetEnemy = _enemyOne;
                    UpdateTargetEnemyUI();
                }
                break;
            default:
                Debug.Log("Something is wrong when targetting next enemy");
                break;
        }

        timeBeforeNextAction = moveRepeatDelay;
    }

    private void CyclePreviousTarget()
    {
        switch(_numberOfEnemies)
        {
            case 1:
                break;
            case 2:
                if (_currentTargetPosition == enemyPositionOne){
                    _currentTargetPosition = enemyPositionTwo;
                    _currentTargetEnemy = _enemyTwo;
                    UpdateTargetEnemyUI();
                }
                else if (_currentTargetPosition == enemyPositionTwo){
                    _currentTargetPosition = enemyPositionOne;
                    _currentTargetEnemy = _enemyOne;
                    UpdateTargetEnemyUI();
                }
                break;
            case 3:
                if (_currentTargetPosition == enemyPositionOne){
                    _currentTargetPosition = enemyPositionThree;
                    _currentTargetEnemy = _enemyThree;
                    UpdateTargetEnemyUI();
                }
                else if (_currentTargetPosition == enemyPositionTwo){
                    _currentTargetPosition = enemyPositionOne;
                    _currentTargetEnemy = _enemyOne;
                    UpdateTargetEnemyUI();
                }
                else if (_currentTargetPosition == enemyPositionThree){
                    _currentTargetPosition = enemyPositionTwo;
                    _currentTargetEnemy = _enemyTwo;
                    UpdateTargetEnemyUI();
                }
                break;
            default:
                Debug.Log("Something is wrong when targetting previous enemy");
                break;
        }

        timeBeforeNextAction = moveRepeatDelay;
    }

    public void CreateTargetEnemyUI()
    {
        _gameReferenceManager.uiManager.CreateEnemyTargetUI(_currentTargetPosition.transform.position, _currentTargetEnemy.gameObject, _currentTargetEnemy.enemyName, _currentTargetEnemy.currentHealth, _currentTargetEnemy.maxHealth);
    }

    public void UpdateTargetEnemyUI()
    {
        _gameReferenceManager.uiManager.ChangeEnemyTargetUIPosition(_currentTargetPosition.transform.position, _currentTargetEnemy.gameObject, _currentTargetEnemy.enemyName, _currentTargetEnemy.currentHealth, _currentTargetEnemy.maxHealth);
    }

    public void CancelTargetSelect()
    {
        if (timeBeforeNextAction != 0f)
        {
            return;
        }

        switch(currentPlayerBattleAction)
        {
            case PlayerBattleAction.Attack:
                ChangeToBattleActionMenuState();
                break;
            case PlayerBattleAction.Catch:
                break;
            case PlayerBattleAction.Sticker:
                break;
            case PlayerBattleAction.Run:
                break;
            default:
                Debug.Log("Something is wrong with the Cancel Target Select method");
                break;
        }

        timeBeforeNextAction = moveRepeatDelay;
    }

    public void ChooseTarget()
    {
        if (timeBeforeNextAction != 0f)
        {
            return;
        }

        timeBeforeNextAction = moveRepeatDelay;

        ChangeToPerformAttackState();
    }

    public void CycleSelectedSticker()
    {
        if (timeBeforeNextAction != 0f)
        {
            return;
        }
        else
        {
            float xInput = CheckInputDirectionX();
            float yInput = CheckInputDirectionY();

            if (xInput != 0f || yInput != 0f)
            {ChangeSelectedSticker(xInput, yInput);}
        }
    }

    private void ChangeSelectedSticker(float xInput, float yInput)
    {
        bool xInputStronger = IsXInputStrongValue(xInput, yInput);

        if (!xInputStronger)
        {ChangeSelectedStickerYAxis(yInput);}
        else 
        {ChangeSelectedStickerXAxis(xInput);}
    }

    private void ChangeSelectedStickerYAxis(float directionFloat)
    {
        if (directionFloat > 0f)
        {
            _gameReferenceManager.uiManager.stickerGridArea.CheckGridObjectBelow();
        }
        else if (directionFloat < 0f)
        {
            _gameReferenceManager.uiManager.stickerGridArea.CheckGridObjectAbove();
        }

        _gameReferenceManager.uiManager.ChangeSelectedStickerUI();
        timeBeforeNextAction = moveRepeatDelay;
    } 

    private void ChangeSelectedStickerXAxis(float directionFloat)
    {
        if (directionFloat > 0f)
        {
            _gameReferenceManager.uiManager.stickerGridArea.CheckGridObjectRight();
        }
        else if (directionFloat < 0f)
        {
            _gameReferenceManager.uiManager.stickerGridArea.CheckGridObjectLeft();
        }

        _gameReferenceManager.uiManager.ChangeSelectedStickerUI();
        timeBeforeNextAction = moveRepeatDelay;
    }

    public float CheckInputDirectionX()
    {
        float xInput = _directionInput.x;

        if (xInput != 0f) {return xInput;}
        else {return 0f;}
    }

    public float CheckInputDirectionY()
    {
        float yInput = _directionInput.y;

        if (yInput != 0f) {return yInput;}
        else {return 0f;}
    }

    public bool IsXInputStrongValue(float x, float y)
    {
        float xAbs = Mathf.Abs(x);
        float yAbs = Mathf.Abs(y);

        if (xAbs > yAbs) {return true;}
        else {return false;}
    }

    public void CancelChooseSticker()
    {
        ChangeToBattleActionMenuState();
    }

    public void AttackTarget()
    {
        StartCoroutine(AttackEnemy());
    }

    IEnumerator AttackEnemy()
    {
        _currentTargetEnemy.TakeDamage(_gameReferenceManager.playerStats.strength);

        _gameReferenceManager.uiManager.CreateFloatingDmgText(_gameReferenceManager.playerStats.strength, _currentTargetPosition.transform.position, _currentTargetEnemy.gameObject);

        StartCoroutine(_gameReferenceManager.player.animationManager.PlayAttackBasic());

        yield return new WaitForEndOfFrame();

        ChangeToEnemyTurnState();
    }

    public void StartEnemyTurnCoroutine()
    {
        StartCoroutine(EnemyTurn()); 
    }

    IEnumerator EnemyOneTurn()
    {
        if (_enemyOne)
        {
            _enemyOne.DoCurrentQueuedAction(_gameReferenceManager.player.gameObject);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator EnemyTwoTurn()
    {
        if (_enemyTwo)
        {
            _enemyTwo.DoCurrentQueuedAction(_gameReferenceManager.player.gameObject);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator EnemyThreeTurn()
    {
        if (_enemyTwo)
        {
            _enemyThree.DoCurrentQueuedAction(_gameReferenceManager.player.gameObject);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(EnemyOneTurn());
        yield return StartCoroutine(EnemyTwoTurn());
        yield return StartCoroutine(EnemyThreeTurn());
        
        yield return new WaitForEndOfFrame();
        ChangeToBattleActionMenuState();
    }

    void OnEastButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            eastButtonPressed?.Invoke();
        }
        else if (context.performed)
        {
               
        }
        else if (context.canceled)
        {

        }
        
    }

    void OnSouthButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            southButtonPressed?.Invoke();
        }
        else if (context.performed)
        {
               
        }
        else if (context.canceled)
        {

        }
        
    }

    void OnWestButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            westButtonPressed?.Invoke();
        }
        else if (context.performed)
        {
               
        }
        else if (context.canceled)
        {

        }
        
    }

    void OnNorthButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            northButtonPressed?.Invoke();
        }
        else if (context.performed)
        {
               
        }
        else if (context.canceled)
        {

        }
        
    }
}
