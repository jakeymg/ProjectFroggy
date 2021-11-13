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
