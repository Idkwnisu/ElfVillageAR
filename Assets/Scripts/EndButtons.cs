using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButtons : MonoBehaviour
{
    public string[] turnOffEnding;
    public string[] blowupEnding;

    public GameObject buttons;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOff()
    {
        DialogueManager.Instance.startDialogue(turnOffEnding);
        MissionManager.Instance.gameOver = true;
        MissionManager.Instance.destroyed = false;
       buttons.SetActive(false);
    }

    public void BlowUp()
    {
        DialogueManager.Instance.startDialogue(blowupEnding);
        MissionManager.Instance.gameOver = true;
        MissionManager.Instance.destroyed = true;
        buttons.SetActive(false);
    }
}
