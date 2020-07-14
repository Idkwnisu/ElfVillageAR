using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownColor : MonoBehaviour
{
    public ColorSelector color;

    public bool up;

    private SelectableItem item;

    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<SelectableItem>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(item.isSelected())
        {
            item.Unselect();
                   if(up)
                   {
                       color.nextMat();
                   }
                   else
                   {
                       color.previousMat();
                   }
        }
    }
}
