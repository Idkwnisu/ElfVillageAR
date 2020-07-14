using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnItem : MonoBehaviour
{

    public bool turnedOn = false;
    public Material onMaterial;

    private Material beginMat;

    public Material failedMat;

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

                    turnedOn = true;
                    GetComponent<Renderer>().material = onMaterial;
        }
    }

    public void Reset()
    {
        turnedOn = false;
        GetComponent<Renderer>().material = beginMat;
    }

    public void failMat()
    {
        GetComponent<Renderer>().material = failedMat;
    }
}
