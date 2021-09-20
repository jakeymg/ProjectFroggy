using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptTrigger : MonoBehaviour
{
    [SerializeField] private UIManager _uimanager;
    [SerializeField] private string _promptString;
    [SerializeField] private SignDialougeObject _signText;
    [SerializeField] private bool _interactionIsTriggerable;
    [SerializeField] private Player _player;
    public bool InteractionIsTriggerable {get{ return _interactionIsTriggerable;}}

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            _uimanager.ShowActionPrompt(_promptString);
            _interactionIsTriggerable = true;
            _player = other.GetComponent<Player>();
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
        _uimanager.OpenDialougePanel(_signText);
        DisableDialougeTrigger();
    }

    private void DisableDialougeTrigger()
    {
        _player.mainButtonPressed -= TriggerDialouge;
    }

    private void EnableDialougeTrigger()
    {
        _player.mainButtonPressed += TriggerDialouge;
    }

}
