using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTurnedOn : MonoBehaviour
{
    public TurnOnItem[] items;

    public bool timed = false; 
    bool completed = false;
    public float howManySeconds = 10;


    float startTime;
    public string MissionToEnd;
    public Material completedMat;

    public GameObject[] toDeactivate;

    public TimerRotation rot;

    private bool startTimer = false;
    // Start is called before the first frame update
    void OnEnable()
    {
        if(timed)  
        {
            startTimer = true;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer && !DialogueManager.Instance.isOnDialogue)
        {
            startTimer = false;
            GameOverTimerManager.Instance.setTimer(howManySeconds);
            rot.startUp(howManySeconds);
        }
        if(!completed)
        {
            if(timed && GameOverTimerManager.Instance.timerOver)
            {
                resetItems();
                MissionManager.Instance.FailMission(MissionToEnd);
                GameOverTimerManager.Instance.defuse();
                for(int i = 0; i < toDeactivate.Length; i++)
                {
                    toDeactivate[i].SetActive(false);
                }
            }
            else
            {
                
            completed = true;
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
                }
            }
            }
        }
    }

    public void StartTimer()
    {
       GameOverTimerManager.Instance.setTimer(howManySeconds);
        
    }

    public void resetItems()
    {
        for(int i = 0; i < items.Length; i++)
        {
            items[i].Reset();
        }
    }
}
