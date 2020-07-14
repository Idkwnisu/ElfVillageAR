using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTurnedOnRightOnes : MonoBehaviour
{
    public TurnOnItem[] items;
    public TurnOnItem[] noItems;
    
    public GameObject[] toDeactivate;

    public bool timed = false; 
    bool completed = false;
    public float howManySeconds = 10;

        public float wrongTime = 0.2f;


    float startTime;
    public string MissionToEnd;
    public Material completedMat;
    // Start is called before the first frame update
    void Start()
    {
        if(timed)  
        {
            GameOverTimerManager.Instance.setTimer(howManySeconds);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!completed)
        {
        completed = true;
        for(int i = 0; i < noItems.Length; i++)
        {
            if(noItems[i].turnedOn)
            {
               Fail();
            }
        }
        for(int i = 0; i < items.Length; i++)
        {
            if(!items[i].turnedOn)
            {
                completed = false;
            }
        }
        if(completed)
        {
            GetComponent<MeshRenderer>().material = completedMat;
            if(MissionManager.Instance.currentMission == MissionToEnd)
            {
                MissionManager.Instance.CompleteMission(MissionToEnd);
                if(timed)
                {
                    GameOverTimerManager.Instance.defuse();
                }
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
        for(int i = 0; i < noItems.Length; i++)
        {
            noItems[i].failMat();
        }
        Invoke("Reset",wrongTime);
    }

    public void Reset()
    {

        for(int i = 0; i < items.Length; i++)
        {
            items[i].Reset();
        }
        for(int i = 0; i < noItems.Length; i++)
        {
            noItems[i].Reset();
        }
    }

    public void StartTimer()
    {
       GameOverTimerManager.Instance.setTimer(howManySeconds);
        
    }
}
