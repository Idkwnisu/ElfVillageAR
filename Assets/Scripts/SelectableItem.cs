using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableItem : MonoBehaviour
{
    private float selectionTime;
    private bool selected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select()
    {
        if(!selected)
            selectionTime = Time.time;
        selected = true;
        Invoke("Unselect", 0.5f);
    }

    public void Unselect()
    {
        selected = false;
    }

    public bool selectedSinceTime(float time)
    {
        if(selected)
        {   
            if(Time.time - selectionTime > time)
            {
                return true;
            }
        }
        return false;
    }

    public bool isSelected()
    {
        return selected;
    }
}
