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
    [SerializeField] private GameObject enemyOne;
    [SerializeField] private Vector3 enemyOneTransformPosition;
    [SerializeField] private GameObject enemyTwo;
    [SerializeField] private Vector3 enemyTwoTransformPosition;
    [SerializeField] private GameObject enemyThree;
    [SerializeField] private Vector3 enemyThreeTransformPosition;

    
    // EVENTS
    public event Action eastButtonPressed;
    public event Action southButtonPressed;
    public event Action westButtonPressed;
    public event Action northButtonPressed;

    private void Awake() 
    {
        _stateMachine = GetComponent<StateMachine>(); if (_stateMachine == null) { Debug.Log("Player State Machine cannot be found");}
        _animationManager = GetComponent<PlayerAnimationManager>(); if (_animationManager == null) { Debug.Log("Player Animation Manager cannot be found");}
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
        SetStartingBattleAction();
        SetEnemyTransformStartingPosition();
    }

    private void FixedUpdate() 
    {
        CheckDirectionInput();
        CheckTimeBeforeNextAction();
        CycleBattleMenu();
    }

    private void SetStartingBattleAction()
    {
        string newPlayerBattleActionString = defaultPlayerBattleAction.ToString();
        _uimanager.ChangePlayerBattleActionText(newPlayerBattleActionString);
    }

    private void SetEnemyTransformStartingPosition()
    {
        if (enemyOne != null)
        {
            enemyOneTransformPosition = enemyOne.transform.position;
        }
        else
        {
            Debug.Log("Enemy One is not assigned or present in scene.");
        }

        if (enemyTwo != null)
        {
            enemyTwoTransformPosition = enemyTwo.transform.position;
        }
        else
        {
            Debug.Log("Enemy Two is not assigned or present in scene.");
        }

        if (enemyThree != null)
        {
            enemyThreeTransformPosition = enemyThree.transform.position;
        }
        else
        {
            Debug.Log("Enemy Three is not assigned or present in scene.");
        }
    }

    public void ChangeToBattleActionMenuState()
    {
        _stateMachine.InitialiseStateMachine(new BattleActionMenuState(this));
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

    private void CheckDirectionInput()
    {
        _directionInput = playerControls.BattleControls.Move.ReadValue<Vector2>();
    }

    private void CheckTimeBeforeNextAction()
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

    private void CycleBattleMenu()
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

    private void CycleTarget()
    {
        if (timeBeforeNextAction != 0f)
        {
            return;
        }
        else
        {
            if (_directionInput.x > 0f)
            {
                //CycleNextTargt();
            }
            else if (_directionInput.x < 0f)
            {
                //CyclePreviousTarget();
            }
        }
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
