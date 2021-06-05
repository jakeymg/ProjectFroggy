using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _playerSpeed = 5.0f;
    [SerializeField] private Vector3 _playerVelocity;
    [SerializeField] private Vector3 _slideDirection = Vector3.zero;
    [SerializeField] private bool playerIsMoving;
    [SerializeField] private bool playerIsSliding;
    [SerializeField] private bool playerIsFalling;

    [Header("Gravity Settings")]
    [SerializeField] private float _gravity = -6.81f;
    [SerializeField] private float _maxVelocityY = -14.0f;

    [Header("Ground/Slope Settings")]
    [SerializeField] private float _startDistanceFromBottom = 0.2f;
    [SerializeField] private float _sphereCastRadius = 0.25f;
    [SerializeField] private float _sphereCastDistance = 0.3f;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float _slideFrictionMultiplier = 0.1f;

    [Header("Ground Raycast Settings")]
    public bool showDebug = false;
    [SerializeField] private float _raycastLength = 0.75f;
    [SerializeField] private Vector3 _rayOriginOffset1 = new Vector3(-0.3f, 0f, 0.2f);
    [SerializeField] private Vector3 _rayOriginOffset2 = new Vector3(0.3f, 0f, -0.2f);

    [Header("Calculation Results")]
    [SerializeField] private bool _isGrounded;
    [SerializeField] private float _groundSlopeAngle= 0f;
    [SerializeField] private Vector3 groundSlopeDir = Vector3.zero;
    private Vector2 moveVal;
    private Vector3 moveDirection;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Ground = LayerMask.GetMask("Ground");

        if (_controller == null)
        {
            Debug.Log("Character controller cannot be found");
        }
    }

    void FixedUpdate()
    {
        CheckIfGrounded();

        CheckSlopeAngle();

        MovePlayer();
    }

    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();       
    }
    private void MovePlayer()
    {   
        ApplySlide();
        ApplyGravity();

        moveDirection = new Vector3(moveVal.x, 0, moveVal.y);

        if (playerIsSliding)
        {
            _controller.Move(moveDirection * Time.deltaTime * (_playerSpeed * _slideFrictionMultiplier));
        }
        else
        {
            _controller.Move(moveDirection * Time.deltaTime * _playerSpeed);
        }

        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }
    }
    private void CheckIfGrounded()
    {
        Vector3 _groundCheckOrigin = new Vector3(transform.position.x, transform.position.y - (_controller.height / 2), transform.position.z);

        _isGrounded = Physics.CheckSphere(_groundCheckOrigin, _sphereCastRadius, Ground, QueryTriggerInteraction.Ignore);

        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = _gravity;
        }
    }
    private void CheckSlopeAngle()
    {
        if (_isGrounded)
        {
            CheckGround(new Vector3(transform.position.x, transform.position.y - (_controller.height / 2) + _startDistanceFromBottom, transform.position.z));
        }
    }
    private void SlidePlayer()
    {
        _slideDirection += groundSlopeDir * _slideFrictionMultiplier;

        _slideDirection.x = Mathf.Clamp(_slideDirection.x, -5.0f, 5.0f);
        _slideDirection.z = Mathf.Clamp(_slideDirection.z, -5.0f, 5.0f);
        _slideDirection.y = Mathf.Clamp(_slideDirection.y, -5.0f, 5.0f);

        _controller.Move(_slideDirection * Time.deltaTime);
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
    private void ApplySlide()
    {

        if (_isGrounded && _groundSlopeAngle >= 45f)
        {
            if (showDebug) {print("Player should be sliding");}
            playerIsSliding = true;
            SlidePlayer();

        }
        else if (!_isGrounded && _groundSlopeAngle >= 25f)
        {
            if (showDebug) {print("Player should be falling");}
            playerIsFalling = true;
            SlidePlayer();
        }
        else
        {
            _slideDirection = Vector3.zero;
            playerIsFalling = false;
            playerIsSliding = false;
        }
    }
    public void CheckGround(Vector3 origin)
    {
        // Out hit point from our cast(s)
        RaycastHit hit;

        // SPHERECAST
        // "Casts a sphere along a ray and returns detailed information on what was hit."
        if (Physics.SphereCast(origin, _sphereCastRadius, Vector3.down, out hit, _sphereCastDistance, Ground))
        {
            // Angle of our slope (between these two vectors). 
            // A hit normal is at a 90 degree angle from the surface that is collided with (at the point of collision).
            // e.g. On a flat surface, both vectors are facing straight up, so the angle is 0.
            _groundSlopeAngle = Vector3.Angle(hit.normal, Vector3.up);

            // Find the vector that represents our slope as well. 
            //  temp: basically, finds vector moving across hit surface 
            Vector3 temp = Vector3.Cross(hit.normal, Vector3.down);
            //  Now use this vector and the hit normal, to find the other vector moving up and down the hit surface
            groundSlopeDir = Vector3.Cross(temp, hit.normal);
            groundSlopeDir.Normalize();
            // This will show you the direction the player should be sliding from it's transform towards the ground
            if (showDebug) {Debug.DrawRay(transform.position, groundSlopeDir * 5.0f, Color.red);}
        }

        // Now that's all fine and dandy, but on edges, corners, etc, we get angle values that we don't want.
        // To correct for this, let's do some raycasts. You could do more raycasts, and check for more
        // edge cases here. There are lots of situations that could pop up, so test and see what gives you trouble.
        RaycastHit slopeHit1;
        RaycastHit slopeHit2;

        // FIRST RAYCAST
        if (Physics.Raycast(origin + _rayOriginOffset1, Vector3.down, out slopeHit1, _raycastLength))
        {
            // Debug line to first hit point
            if (showDebug) { Debug.DrawLine(origin + _rayOriginOffset1, slopeHit1.point, Color.red); }
            // Get angle of slope on hit normal
            float angleOne = Vector3.Angle(slopeHit1.normal, Vector3.up);

            // 2ND RAYCAST
            if (Physics.Raycast(origin + _rayOriginOffset2, Vector3.down, out slopeHit2, _raycastLength))
            {
                // Debug line to second hit point
                if (showDebug) { Debug.DrawLine(origin + _rayOriginOffset2, slopeHit2.point, Color.red); }
                // Get angle of slope of these two hit points.
                float angleTwo = Vector3.Angle(slopeHit2.normal, Vector3.up);
                // 3 collision points: Take the MEDIAN by sorting array and grabbing middle.
                float[] tempArray = new float[] { _groundSlopeAngle, angleOne, angleTwo };
                Array.Sort(tempArray);
                _groundSlopeAngle = tempArray[1];
            }
            else
            {
                // 2 collision points (sphere and first raycast): AVERAGE the two
                float average = (_groundSlopeAngle + angleOne) / 2;
		_groundSlopeAngle = average;
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        if (showDebug)
        {
            // Visualize SphereCast with two spheres and a line
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
