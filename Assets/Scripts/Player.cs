using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;
    [SerializeField]
    private Transform _groundChecker;
    [SerializeField]
    private LayerMask Ground;
    [SerializeField]
    private float _groundCheckerRadius = 0.2f;
    [SerializeField]
    private Vector3 _playerVelocity;
    private float _maxVelocityY = -14.0f;
    [SerializeField]
    private float _playerSpeed = 5.0f;
    [SerializeField]
    private float _jumpHeight = 1.0f;
    [SerializeField]
    private float _gravity = -6.81f;
    [SerializeField]
    private bool _isGrounded;
    private Vector2 moveVal;
    private Vector3 moveDirection;
    private Vector3 slideDirection;
    [SerializeField]
    private float _slideFriction = 0.3f;
    private Vector3 slopeNormal;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _groundChecker = GameObject.Find("GroundChecker").GetComponent<Transform>();
        Ground = LayerMask.GetMask("Ground");

        if (_controller == null)
        {
            Debug.Log("Character controller cannot be found");
        }

        if (_groundChecker == null)
        {
            Debug.Log("Ground Checker couldn't be found");
        }
    }

    void Update()
    {
        SlideMovement();
        MovePlayer();
    }

    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();       
    }

    private void MovePlayer()
    {      
        CheckIfGrounded();

        moveDirection = new Vector3(moveVal.x, 0, moveVal.y);

        _controller.Move(moveDirection * Time.deltaTime * _playerSpeed);

        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }

        CheckSlope();

        ApplyGravity();
    }

    private void CheckSlope()
    {
        _isGrounded = Vector3.Angle (Vector3.up, slopeNormal) <= _controller.slopeLimit;
    }

    private void SlideMovement()
    {
        if (!_isGrounded) 
        {
            slideDirection.x += (1f - slopeNormal.y) * slopeNormal.x * (_playerSpeed - _slideFriction);
            slideDirection.z += (1f - slopeNormal.y) * slopeNormal.z * (_playerSpeed - _slideFriction);
            _controller.Move(slideDirection * Time.deltaTime);
        }
    }

    private void CheckIfGrounded()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, _groundCheckerRadius, Ground, QueryTriggerInteraction.Ignore);

        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = _gravity;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        slopeNormal = hit.normal;
    }

    private void ApplyGravity()
    {
        _playerVelocity.y += _gravity * Time.deltaTime;

        if (_playerVelocity.y <= _maxVelocityY)
        {
            _playerVelocity.y = _maxVelocityY;
        }

        _controller.Move(_playerVelocity * Time.deltaTime);
    }
}
