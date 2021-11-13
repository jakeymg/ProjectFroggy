using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Player : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private PlayerAnimationManager _animationManager;
    [SerializeField] private UIManager _uimanager;
    [SerializeField] private GameObject _interactableTarget;
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

    [Header("Movement Settings")]
    [SerializeField] private float _playerSpeed = 5.0f;
    [SerializeField] private Vector3 _playerVelocity;
    [SerializeField] private Vector3 _slideDirection = Vector3.zero;
    [SerializeField] private float _maxSlideSpeed = 3.0f;
    [SerializeField] private string _currentState;

    [Header("Gravity Settings")]
    [SerializeField] private float _gravity = -6.81f;
    [SerializeField] private float _maxVelocityY = -14.0f;

    [Header("Ground/Slope Settings")]
    [SerializeField] private float _startDistanceFromBottom = 0.2f;
    [SerializeField] private float _sphereCastRadius = 0.25f;
    [SerializeField] private float _sphereCastDistance = 0.3f;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float _slideFrictionMultiplier = 0.35f;

    [Header("Ground Raycast Settings")]
    public bool showDebug = false;
    [SerializeField] private float _raycastLength = 0.75f;
    [SerializeField] private Vector3 _rayOriginOffset1 = new Vector3(-0.3f, 0f, 0.2f);
    [SerializeField] private Vector3 _rayOriginOffset2 = new Vector3(0.3f, 0f, -0.2f);
    [SerializeField] private float _rayOriginOffset3 = 0.3f;

    [Header("Calculation Results")]
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isOnEdge;
    [SerializeField] private float _groundSlopeAngle= 0f;
    [SerializeField] private Vector3 groundSlopeDir = Vector3.zero;
    [SerializeField] private Vector2 moveVal;
    [SerializeField] private Vector2 _rightStickVal;
    [SerializeField] private Vector3 moveDirection;

    [SerializeField] private float moveVelocity;

    [Header("Particle Systems")]
    [SerializeField] private ParticleSystem _movementDust;

    private void Awake() 
    {
        _controller = GetComponent<CharacterController>(); if (_controller == null) { Debug.Log("Character controller cannot be found");}
        _stateMachine = GetComponent<StateMachine>(); if (_stateMachine == null) { Debug.Log("Player State Machine cannot be found");}
        _animationManager = GetComponent<PlayerAnimationManager>(); if (_animationManager == null) { Debug.Log("Player Animation Manager cannot be found");}
        _movementDust = GameObject.Find("movementDust_Ps").GetComponent<ParticleSystem>(); if (_movementDust == null) {Debug.Log("Movement Dust particle system can't be found");}
        playerInput = GetComponent<PlayerInput>(); if (playerInput == null) { Debug.Log("Player Input cannot be found");}
        playerStats = GetComponent<PlayerStats>(); if (playerStats == null) { Debug.Log("Player Stats cannot be found");}

        if (_mainCamera == null) { Debug.Log("Player Follow Camera cannot be found");}
        _mainCameraFramingTransposer = _mainCamera.GetCinemachineComponent<CinemachineFramingTransposer>();

        playerControls = new PlayerControls();
        playerControls.Gameplay.Enable();

        playerControls.Gameplay.EastButton.started += OnEastButton;
        playerControls.Gameplay.EastButton.performed += OnEastButton;
        playerControls.Gameplay.EastButton.canceled += OnEastButton;

        playerControls.Gameplay.SouthButton.started += OnSouthButton;
        playerControls.Gameplay.SouthButton.performed += OnSouthButton;
        playerControls.Gameplay.SouthButton.canceled += OnSouthButton;

        playerControls.Gameplay.WestButton.started += OnWestButton;
        playerControls.Gameplay.WestButton.performed += OnWestButton;
        playerControls.Gameplay.WestButton.canceled += OnWestButton;

        playerControls.Gameplay.NorthButton.started += OnNorthButton;
        playerControls.Gameplay.NorthButton.performed += OnNorthButton;
        playerControls.Gameplay.NorthButton.canceled += OnNorthButton;

        
        Ground = LayerMask.GetMask("Ground");
    }
    
    void Start()
    {
        ChangeToIdle();
    }

    void Update() 
    {
        
    }

    void FixedUpdate()
    {    
        MovementCheck();
        //RightStickInputCheck();
    }

    void MovementCheck()
    {
        moveVal = playerControls.Gameplay.Move.ReadValue<Vector2>();
        moveVelocity = moveVal.magnitude;
        
        if (_uimanager.IsDialougeActive()) 
        {
            moveVelocity = 0;
        }
        else
        {
            moveVelocity = moveVal.magnitude;
        }
        
        _animationManager.IdleWalkRunMixerValue = moveVelocity;
    }
    
    void RightStickInputCheck()
    {
        _rightStickVal = playerControls.Gameplay.CameraShift.ReadValue<Vector2>();
        ShiftCameraView();
    }

    void ShiftCameraView()
    {
        float defaultCameraDist = 18f;

        float currentYRot = _mainCamera.transform.rotation.y;
        float currentXRot = _mainCamera.transform.rotation.x;

        _mainCameraFramingTransposer.m_CameraDistance = defaultCameraDist + (5f * -_rightStickVal.y);
        _mainCameraFramingTransposer.m_ScreenX = 0.5f + (0.1f * -_rightStickVal.x);
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

    public void SetInteractableTarget(GameObject InteractableTarget)
    {
        _interactableTarget = InteractableTarget;
    }

    public void RemoveInteractableTarget()
    {
        _interactableTarget = null;
    }

    public void ChangeToSitting()
    {
        _stateMachine.ChangeState(new SitState(this));
    }

    public void ChangeToIdle()
    {
        _stateMachine.InitialiseStateMachine(new IdleState(this));
    }

    public void MovePlayer(float speedModifier = 1f)
    {
        if (_uimanager.IsDialougeActive()) return;

        moveDirection = new Vector3(moveVal.x, 0, moveVal.y);
        
        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }

        _controller.Move(moveDirection * Time.deltaTime * (_playerSpeed * speedModifier));

        //SlidePlayer();
        //ApplyGravity();
    }

    public void CheckIfGrounded()
    {
        Vector3 _groundCheckOrigin = new Vector3(transform.position.x, transform.position.y - (_controller.height / 2), transform.position.z);

        _isGrounded = Physics.CheckSphere(_groundCheckOrigin, _sphereCastRadius, Ground, QueryTriggerInteraction.Ignore);

        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = _gravity;
        }
    }

    public void CheckSlopeAngle()
    {
        if (_isGrounded)
        {
            CheckGround(new Vector3(transform.position.x, transform.position.y - (_controller.height / 2) + _startDistanceFromBottom, transform.position.z));
        }
    }

    public void SlidePlayer()
    {
        _slideDirection += groundSlopeDir * _slideFrictionMultiplier;

        _slideDirection.x = Mathf.Clamp(_slideDirection.x, -_maxSlideSpeed, _maxSlideSpeed);
        _slideDirection.z = Mathf.Clamp(_slideDirection.z, -_maxSlideSpeed, _maxSlideSpeed);
        _slideDirection.y = Mathf.Clamp(_slideDirection.y, -_maxSlideSpeed, _maxSlideSpeed);

        _controller.Move(_slideDirection * Time.deltaTime);
    }

    public void ApplyGravity()
    {
        _playerVelocity.y += _gravity * Time.deltaTime;

        if (_playerVelocity.y <= _maxVelocityY)
        {
            _playerVelocity.y = _maxVelocityY;
        }

        _controller.Move(_playerVelocity * Time.deltaTime);
    }
    
    private void ShouldPlayerBeIdle()
    {
        if (_uimanager.IsDialougeActive()) return;
        
        if (_stateMachine.currentState.GetType().ToString() != "SitState" && _stateMachine.currentState.GetType().ToString() != "IdleState")
        {
            ChangeToIdle();
        }
    }

    public void ShouldPlayerSlideOrFall()
    {
        //This could be way cleaner - Basically all my checks

        if (_isGrounded && _groundSlopeAngle >= 45f)
        {
            if (showDebug) {print("Player should be sliding");}
            _stateMachine.ChangeState(new SlideState(this));
        }

        else if (!_isGrounded && _groundSlopeAngle >= 5f)
        {
            if (showDebug) {print("Player should be falling");}
            _stateMachine.ChangeState(new FallState(this));
        }

        else if (_isOnEdge)
        {
            if (showDebug) {print("Player is too far off edge");}
            
            if (_groundSlopeAngle >= 0f)
            {
                _stateMachine.ChangeState(new SlideState(this)); 
                Debug.Log("Feeling Wobbly"); /* WobbleState eventually */ 
            }
            else {_stateMachine.ChangeState(new FallState(this));}
        }

        else 
        {
            _slideDirection = Vector3.zero;
            ShouldPlayerRunOrWalk();
        }
    }

    private void ShouldPlayerRunOrWalk()
    {
        if (moveVal != Vector2.zero)
        {
            if (moveVelocity >= 0.6f)
            {
                _stateMachine.ChangeState(new RunState(this));
            }
            else
            {
                _stateMachine.ChangeState(new WalkState(this));
            }
        }
        else
        {
            ShouldPlayerBeIdle();
        }
    }

    public void PlayDustParticle()
    {
        if (_uimanager.IsDialougeActive()) return;
        _movementDust.Play();
    }

    public void CheckGround(Vector3 origin)
    {
        RaycastHit hit;

        if (Physics.SphereCast(origin, _sphereCastRadius, Vector3.down, out hit, _sphereCastDistance, Ground))
        {
            _groundSlopeAngle = Vector3.Angle(hit.normal, Vector3.up);

            Vector3 temp = Vector3.Cross(hit.normal, Vector3.down);
            groundSlopeDir = Vector3.Cross(temp, hit.normal);
            groundSlopeDir.Normalize();
            if (showDebug) {Debug.DrawRay(transform.position, groundSlopeDir * 5.0f, Color.red);}
        }

        RaycastHit slopeHit1;
        RaycastHit slopeHit2;
        RaycastHit slopeHit3;

        if (Physics.Raycast(origin + _rayOriginOffset1, Vector3.down, out slopeHit1, _raycastLength))
        {
            if (showDebug) { Debug.DrawLine(origin + _rayOriginOffset1, slopeHit1.point, Color.red); }
            float angleOne = Vector3.Angle(slopeHit1.normal, Vector3.up);

            if (Physics.Raycast(origin + _rayOriginOffset2, Vector3.down, out slopeHit2, _raycastLength))
            {
                if (showDebug) { Debug.DrawLine(origin + _rayOriginOffset2, slopeHit2.point, Color.red); }
                float angleTwo = Vector3.Angle(slopeHit2.normal, Vector3.up);
                float[] tempArray = new float[] { _groundSlopeAngle, angleOne, angleTwo };
                Array.Sort(tempArray);
                _groundSlopeAngle = tempArray[1];
            }
            else
            {
                float average = (_groundSlopeAngle + angleOne) / 2;
		        _groundSlopeAngle = average;
            }
        }

        if (!Physics.Raycast(origin + (transform.forward * _rayOriginOffset3), Vector3.down, out slopeHit3, _raycastLength))
        {
            _isOnEdge = true;
        }
        else if (Physics.Raycast(origin + (transform.forward * _rayOriginOffset3), Vector3.down, out slopeHit3, _raycastLength))
        {
            _isOnEdge = false;
        }

        Debug.DrawLine(origin + (transform.forward * _rayOriginOffset3), (origin + (transform.forward * _rayOriginOffset3)) - new Vector3(0f, _raycastLength, 0f), Color.red);
    }

    void OnDrawGizmosSelected()
    {
        if (showDebug)
        {
            Vector3 startPoint = new Vector3(transform.position.x, transform.position.y - (_controller.height / 2) + _startDistanceFromBottom, transform.position.z);
            Vector3 endPoint = new Vector3(transform.position.x, transform.position.y - (_controller.height / 2) + _startDistanceFromBottom - _sphereCastDistance, transform.position.z);

            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(startPoint, _sphereCastDistance);

            Gizmos.color = Color.gray;
            Gizmos.DrawWireSphere(endPoint, _sphereCastRadius);

            Gizmos.DrawLine(startPoint, endPoint);
        }
    }
}
