using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject[] ToDeactivate;
    public GameObject[] ToActivate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyBuildings()
    {
        for(int i = 0; i < ToDeactivate.Length; i++)
        {
            ToDeactivate[i].SetActive(false);
        }
        for(int i = 0; i < ToActivate.Length; i++)
        {
            ToActivate[i].SetActive(true);
        }
        DialogueManager.Instance.stopDialogue();
    }
}
