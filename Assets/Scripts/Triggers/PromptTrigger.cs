using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PromptTrigger : MonoBehaviour
{
    [SerializeField] private UIManager _uimanager;
    [SerializeField] private string _promptString;
    [SerializeField] private SignDialougeObject _signText;
    [SerializeField] private bool _interactionIsTriggerable;
    [SerializeField] private CinemachineVirtualCamera _dialougeCamera;
    [SerializeField] private Player _player;
    public bool InteractionIsTriggerable {get{ return _interactionIsTriggerable;}}

    private void Awake() 
    {
        _dialougeCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            _player = other.GetComponent<Player>();
            _uimanager.ShowActionPrompt(_promptString);
            _interactionIsTriggerable = true;
            _player.SetInteractableTarget(this.gameObject);
            EnableDialougeTrigger();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            _uimanager.HideActionPrompt();
            _interactionIsTriggerable = false;
            _player.RemoveInteractableTarget();
            DisableDialougeTrigger();
            
            _player = null;
        }
    }

    private void TriggerDialouge()
    {
        _uimanager.OpenDialougePanel(_signText, this.GetComponent<PromptTrigger>());
        DisableDialougeTrigger();
    }

    public void DisableDialougeTrigger()
    {
        _player.eastButtonPressed -= TriggerDialouge;
    }

    public void EnableDialougeTrigger()
    {
        _player.eastButtonPressed += TriggerDialouge;
    }

    public void ChangeToDialougeCamera()
    {
        _dialougeCamera.Priority = 10;
    }

    public void ChangeToPlayerCamera()
    {
        _dialougeCamera.Priority = 0;
    }

}
