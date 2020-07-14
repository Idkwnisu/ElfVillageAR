using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disappear : MonoBehaviour
{
    public float speed = 0.02f;
    Material material;
    float treshold = 0.0f;

    public string[] startDialogues;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Image>().material;
        material.SetFloat("_Treshold", 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        treshold += speed;
        material.SetFloat("_Treshold", treshold);
        if(treshold >= 1.0)
        {
            gameObject.SetActive(false);
            DialogueManager.Instance.startDialogue(startDialogues);
        }
    }
}
