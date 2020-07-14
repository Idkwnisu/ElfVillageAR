using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTurnedOnOrdered : MonoBehaviour
{
    public TurnOnItemOrdered[] items;
    bool completed = false;

    public string MissionToEnd;
    public Material completedMat;

    public GameObject[] toDeactivate;

    public float wrongTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!completed)
        {
        completed = true;
        for(int i = 0; i < items.Length; i++)
        {
            if(!items[i].turnedOn)
            {
                completed = false;
            }
            if(items[i].failed)
            {
                Fail();
            }
        }
        if(completed)
        {
            GetComponent<MeshRenderer>().material = completedMat;
            if(MissionManager.Instance.currentMission == MissionToEnd)
            {
                MissionManager.Instance.CompleteMission(MissionToEnd);
                for(int i = 0; i < toDeactivate.Length; i++)
                {
                    toDeactivate[i].SetActive(false);
                }
            }
        }
        }
    }

    public void Fail()
    {
        for(int i = 0; i < items.Length; i++)
        {
            items[i].failMat();
        }
        Invoke("Reset",wrongTime);
    }

    public void Reset()
    {

        for(int i = 0; i < items.Length; i++)
        {
            items[i].Reset();
        }
    }
}
