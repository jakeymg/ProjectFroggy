using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptTrigger : MonoBehaviour
{
    [SerializeField] private UIManager _uimanager;
    [SerializeField] private string _promptString;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            _uimanager.ShowActionPrompt(_promptString);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            _uimanager.HideActionPrompt();
        }
    }
}
