using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;
    [SerializeField]
    private Vector3 _playerVelocity;
    [SerializeField]
    private float _playerSpeed = 5.0f;
    [SerializeField]
    private float _jumpHeight = 1.0f;
    [SerializeField]
    private float _gravity = -9.81f;
    private Vector3 moveDirection;

    void Start()
    {
        _controller = GetComponent<CharacterController>();

        if (_controller == null)
        {
            Debug.Log("Character controller cannot be found");
        }
    }

    void Update()
    {
        

        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        _controller.Move(Vector3.ClampMagnitude(moveDirection, 1.0f) * Time.deltaTime * _playerSpeed);

        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }
    }
}
