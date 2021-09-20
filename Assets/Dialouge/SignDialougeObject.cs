using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sign Dialouge", menuName = "Dialouge Object/Sign Dialouge Object")]
public class SignDialougeObject : ScriptableObject
{   
    [SerializeField][TextArea(2, 4)]
    private string[] text;

    public string[] Text {get {return text;}}
}
