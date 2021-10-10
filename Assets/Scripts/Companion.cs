using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector3 offsetPoint;

    private void Awake() 
    {
        transform.position = _player.transform.position - offsetPoint;    
    }

    private void FixedUpdate() 
    {
        transform.position = _player.transform.position - offsetPoint;
    }
}
