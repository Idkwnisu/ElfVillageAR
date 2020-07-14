using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{   
    public string[] startDialogues;
    public GameObject buttons;
    public string[] tutorialDialogues;

    public string[] closeDialogues;
    private bool start = true;
    private bool yes = true;
    // Start is called before the first frame update
    void Start()
    {
        DialogueManager.Instance.startDialogue(startDialogues);   
    }

    // Update is called once per frame
    void Update()
    {
        if(!DialogueManager.Instance.isOnDialogue && start)
        {
            buttons.SetActive(true);
        }
        else if(!DialogueManager.Instance.isOnDialogue)
        {
             SceneManager.LoadScene("SampleScene");
        }

        if(!DialogueManager.Instance.isOnDialogue && !yes)
        {
            Application.Quit();
        }
    }

    public void Yes()
    {
        DialogueManager.Instance.startDialogue(tutorialDialogues); 
        start = false;
        buttons.SetActive(false);
    }

    public void No()
    {
        DialogueManager.Instance.startDialogue(closeDialogues); 
        yes = false;
        buttons.SetActive(false);
    }
}
