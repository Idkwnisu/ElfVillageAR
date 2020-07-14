using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{
    public Material rightPreview;

    public Material wrongPreview;

    public Renderer[] renderers;   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPreview(bool correct)
    {
        if(correct)
        {
            for(int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material = rightPreview;
            }
        }
        else
        {
            for(int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material = wrongPreview;
            }
        }
    }
}
