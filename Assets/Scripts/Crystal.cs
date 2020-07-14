using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public Material selectedMat;
    public Material unselectedMat;

    public Material chargedMat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<SelectableItem>().selectedSinceTime(3.0f))
        {
            GetComponent<MeshRenderer>().material = chargedMat;
        }
        else if(GetComponent<SelectableItem>().isSelected())
        {
            GetComponent<MeshRenderer>().material = selectedMat;
        }
        else
        {
             GetComponent<MeshRenderer>().material = unselectedMat;
        }
    }
}
