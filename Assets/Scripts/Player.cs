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
    [SerializeField] private float _maxSlideSpeed = 3.0f;
    [SerializeField] private bool playerIsWalking;
    [SerializeField] private bool playerIsRunning;
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
    [SerializeField] private Vector3 moveDirection;

    [Header("Particle Systems")]
    [SerializeField] private ParticleSystem _movementDust;

    void Start()
    {
        _controller = GetComponent<CharacterController>(); if (_controller == null) { Debug.Log("Character controller cannot be found");}
        Ground = LayerMask.GetMask("Ground");
        _movementDust = GameObject.Find("movementDust_Ps").GetComponent<ParticleSystem>(); if (_movementDust == null) {Debug.Log("Movement Dust particle system can't be found");}
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
        moveDirection = new Vector3(moveVal.x, 0, moveVal.y);
        
        if (moveDirection != Vector3.zero)
        {
            if (moveVal.x < -0.6f || moveVal.x > 0.6f || moveVal.y < -0.6f || moveVal.y > 0.6f)
            {
                playerIsWalking = false;
                playerIsRunning = true;
                CreateDust();
            }
            else
            {
                playerIsRunning = false;
                playerIsWalking = true;
            }
        }
        else
        {
            playerIsWalking = false;
            playerIsRunning = false;
        }

        if (playerIsFalling)
        {
            _controller.Move(moveDirection * Time.deltaTime * (_playerSpeed / 2.0f));  
        }
        else if (playerIsSliding)
        {
            _controller.Move(moveDirection * Time.deltaTime * (_playerSpeed / 2.0f));
        }
        else
        {
            _controller.Move(moveDirection * Time.deltaTime * _playerSpeed);
        }

        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }

        ApplySlide();
        ApplyGravity();
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

        _slideDirection.x = Mathf.Clamp(_slideDirection.x, -_maxSlideSpeed, _maxSlideSpeed);
        _slideDirection.z = Mathf.Clamp(_slideDirection.z, -_maxSlideSpeed, _maxSlideSpeed);
        _slideDirection.y = Mathf.Clamp(_slideDirection.y, -_maxSlideSpeed, _maxSlideSpeed);

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
            CreateDust();
        }
        else if (!_isGrounded && _groundSlopeAngle >= 5f)
        {
            if (showDebug) {print("Player should be falling");}
            playerIsFalling = true;
            SlidePlayer();
        }
        else if (_isOnEdge)
        {
            if (showDebug) {print("Player is too far off edge");}
            
            if (_groundSlopeAngle >= 1f)
            {
                playerIsSliding = true;
                SlidePlayer();
                CreateDust();
            }
            else
            {
                playerIsFalling = true;
                SlidePlayer();
            }
        }
        else
        {
            _slideDirection = Vector3.zero;
            playerIsFalling = false;
            playerIsSliding = false;
        }
    }

    private void CreateDust()
    {
        if (playerIsSliding)
        {
            _movementDust.Play();
        }
        else if (playerIsFalling)
        {}
        else
        {
            _movementDust.Play();
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
        RaycastHit slopeHit3;

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

        // Check if Player has ground infront
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
