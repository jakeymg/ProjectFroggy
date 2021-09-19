using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sign Dialouge", menuName = "Dialouge Object/Sign Dialouge Object")]
public class SignDialougeObject : ScriptableObject
{   
    [TextArea(2, 4)]
    public string[] text;
}
