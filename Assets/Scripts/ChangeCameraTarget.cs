using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCameraTarget : MonoBehaviour
{
    [SerializeField] private Vector3 defaultPosition;
    [SerializeField] private GameObject targetTransform;
    [SerializeField] private Vector3 transformOffset;
    [SerializeField] private CinemachineVirtualCamera cameraRef;
    [SerializeField] private CinemachineFramingTransposer cameraRefFramingTransposer;
    [SerializeField] private float defaultDistance;

    private void Awake() 
    {
        if (cameraRef == null) { Debug.Log("Player Follow Camera cannot be found");}
        cameraRefFramingTransposer = cameraRef.GetCinemachineComponent<CinemachineFramingTransposer>();

        defaultPosition = this.transform.position;
        defaultDistance = cameraRefFramingTransposer.m_CameraDistance;
    }
    
    public void ChangeTargetPosition(GameObject targetTransform, Vector3 targetOffset)
    {
        this.gameObject.transform.position = targetTransform.transform.position + targetOffset;
    }

    public void ReturnToDefaultPosition()
    {
        this.gameObject.transform.position = defaultPosition;
    }

    public void ChangeFieldOfView(float newDistance)
    {
        cameraRefFramingTransposer.m_CameraDistance = newDistance;
    }

    public void ReturnToDefaultFieldOfView()
    {
        cameraRefFramingTransposer.m_CameraDistance = defaultDistance;
    }
}
