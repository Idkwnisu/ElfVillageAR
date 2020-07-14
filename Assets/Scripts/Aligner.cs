using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aligner : MonoBehaviour
{
    public Transform toAlign;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.enabled = false;
     GetComponent<Camera>().enabled = true;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = toAlign.rotation;
    }
}
