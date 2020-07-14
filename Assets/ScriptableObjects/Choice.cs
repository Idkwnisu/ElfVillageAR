using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Choice", order = 1)]
public class Choice : ScriptableObject
{
    public string firstChoice;
    public string secondChoice;

    public string firstChoiceEvent;

    public string secondChoiceEvent;

}
