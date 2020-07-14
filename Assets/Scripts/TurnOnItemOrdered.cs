using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnItemOrdered : MonoBehaviour
{

    public bool turnedOn = false;
    public Material onMaterial;

    private Material beginMat;

    public bool first = false;

    public bool failed = false;

    public Material failedMat;
    public TurnOnItemOrdered previous;
    private SelectableItem item;
    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<SelectableItem>();
        beginMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(item.isSelected() && !turnedOn)
        {

                    if(first || previous.turnedOn)
                    {
                        turnedOn = true;
                        GetComponent<Renderer>().material = onMaterial;
                    }
                    else
                    {
                        failed = true;
                    }
                
            
        }
    }

    public void Reset()
    {
        turnedOn = false;
        failed = false;
        GetComponent<Renderer>().material = beginMat;
    }

    public void failMat()
    {
        GetComponent<Renderer>().material = failedMat;
    }
}
