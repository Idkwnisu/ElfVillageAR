using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Research", order = 2)]
public class Research : ScriptableObject
{
    public string res_name;
    public string description;

    public string[] dialogues;

    public string[] endDialogues;

    public Research[] requisites;

    public Research[] bonus;

    public Research[] malus;

    public Research[] blocked;
}
