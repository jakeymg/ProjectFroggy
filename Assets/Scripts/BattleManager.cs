using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class BattleManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private PlayerAnimationManager _animationManager;
    [SerializeField] private UIManager _uimanager;
    public UIManager uiManager {get{ return _uimanager;}}
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerControls playerControls;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private CinemachineVirtualCamera _mainCamera;
    [SerializeField] private CinemachineFramingTransposer _mainCameraFramingTransposer;
    
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
    [SerializeField] private GameObject _currentTarget;
    [SerializeField] private GameObject enemyPositionOne;
    [SerializeField] private GameObject enemyPositionTwo;
    [SerializeField] private GameObject enemyPositionThree;
    [SerializeField] private List<GameObject> enemyList;
    
    // EVENTS
    public event Action eastButtonPressed;
    public event Action southButtonPressed;
    public event Action westButtonPressed;
    public event Action northButtonPressed;

    private void Awake() 
    {
        _stateMachine = GetComponent<StateMachine>(); if (_stateMachine == null) { Debug.Log("Player State Machine cannot be found");}
        //_animationManager = GetComponent<PlayerAnimationManager>(); if (_animationManager == null) { Debug.Log("Player Animation Manager cannot be found");}
        playerInput = GetComponent<PlayerInput>(); if (playerInput == null) { Debug.Log("Player Input cannot be found");}
        playerStats = GetComponent<PlayerStats>(); if (playerStats == null) { Debug.Log("Player Stats cannot be found");}

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
        SetFirstTarget(); 
        
    }

    private void FixedUpdate() 
    {
        
    }

    private void SetStartingBattleAction()
    {
        string newPlayerBattleActionString = defaultPlayerBattleAction.ToString();
        _uimanager.ChangePlayerBattleActionText(newPlayerBattleActionString);

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

    public void AssignEnemyToEnemyList(GameObject Enemy)
    {
        enemyList.Add(Enemy);
    }

    private void SetFirstTarget()
    {
        _uimanager.ChangeTargetArrowPosition(enemyPositionOne.transform.position);
        _currentTarget = enemyPositionOne;
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
        _uimanager.ChangePlayerBattleActionText(newPlayerBattleActionString);

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
        _uimanager.ChangePlayerBattleActionText(newPlayerBattleActionString);

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
                if (_currentTarget == enemyPositionOne){
                    _uimanager.ChangeTargetArrowPosition(enemyPositionTwo.transform.position);
                    _currentTarget = enemyPositionTwo;
                }
                else if (_currentTarget == enemyPositionTwo){
                    _uimanager.ChangeTargetArrowPosition(enemyPositionOne.transform.position);
                    _currentTarget = enemyPositionOne;
                }
                break;
            case 3:
                if (_currentTarget == enemyPositionOne){
                    _uimanager.ChangeTargetArrowPosition(enemyPositionTwo.transform.position);
                    _currentTarget = enemyPositionTwo;
                }
                else if (_currentTarget == enemyPositionTwo){
                    _uimanager.ChangeTargetArrowPosition(enemyPositionThree.transform.position);
                    _currentTarget = enemyPositionThree;
                }
                else if (_currentTarget == enemyPositionThree){
                    _uimanager.ChangeTargetArrowPosition(enemyPositionOne.transform.position);
                    _currentTarget = enemyPositionOne;
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
                if (_currentTarget == enemyPositionOne){
                    _uimanager.ChangeTargetArrowPosition(enemyPositionTwo.transform.position);
                    _currentTarget = enemyPositionTwo;
                }
                else if (_currentTarget == enemyPositionTwo){
                    _uimanager.ChangeTargetArrowPosition(enemyPositionOne.transform.position);
                    _currentTarget = enemyPositionOne;
                }
                break;
            case 3:
                if (_currentTarget == enemyPositionOne){
                    _uimanager.ChangeTargetArrowPosition(enemyPositionThree.transform.position);
                    _currentTarget = enemyPositionThree;
                }
                else if (_currentTarget == enemyPositionTwo){
                    _uimanager.ChangeTargetArrowPosition(enemyPositionOne.transform.position);
                    _currentTarget = enemyPositionOne;
                }
                else if (_currentTarget == enemyPositionThree){
                    _uimanager.ChangeTargetArrowPosition(enemyPositionTwo.transform.position);
                    _currentTarget = enemyPositionTwo;
                }
                break;
            default:
                Debug.Log("Something is wrong when targetting previous enemy");
                break;
        }

        timeBeforeNextAction = moveRepeatDelay;
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
            uiManager.stickerGridArea.CheckGridObjectBelow();
        }
        else if (directionFloat < 0f)
        {
            uiManager.stickerGridArea.CheckGridObjectAbove();
        }

        uiManager.ChangeSelectedStickerUI();
        timeBeforeNextAction = moveRepeatDelay;
    } 

    private void ChangeSelectedStickerXAxis(float directionFloat)
    {
        if (directionFloat > 0f)
        {
            uiManager.stickerGridArea.CheckGridObjectRight();
        }
        else if (directionFloat < 0f)
        {
            uiManager.stickerGridArea.CheckGridObjectLeft();
        }

        uiManager.ChangeSelectedStickerUI();
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
