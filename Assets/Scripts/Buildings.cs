using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    public GameObject energyTower;
    public GameObject centralPortal;
    public GameObject timerPortal;
    public GameObject rgbPortal;

    public GameObject finalPortal;

    public GameObject rightPortal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Build(string building)
    {
        if(building == "Energy Tower")
        {
            energyTower.SetActive(true);
        }
        else if(building == "Central Portal")
        {
            centralPortal.SetActive(true);
        }
        else if(building == "Timer Portal")
        {
            timerPortal.SetActive(true);
        }
        else if(building == "RGB Portal")
        {
            rgbPortal.SetActive(true);
        }
        else if(building == "Right Portal")
        {
            rightPortal.SetActive(true);
        }
        else if(building == "Final Portal")
        {
            finalPortal.SetActive(true);
        }
    }

    public void UnBuild(string building)
    {
        if(building == "Energy Tower")
        {
            energyTower.SetActive(false);
        }
        else if(building == "Central Portal")
        {
            centralPortal.SetActive(false);
        }
        else if(building == "Timer Portal")
        {
            timerPortal.SetActive(false);
        }
        else if(building == "RGB Portal")
        {
            rgbPortal.SetActive(false);
        }
        else if(building == "Right Portal")
        {
            rightPortal.SetActive(false);
        }
        else if(building == "Final Portal")
        {
            finalPortal.SetActive(false);
        } 
    }
}
