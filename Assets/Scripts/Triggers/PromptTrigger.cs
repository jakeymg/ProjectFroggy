using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptTrigger : MonoBehaviour
{
    [SerializeField] private UIManager _uimanager;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            _uimanager.ShowActionPrompt("(X) to hide");
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
