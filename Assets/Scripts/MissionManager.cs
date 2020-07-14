using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    public string currentMission;

    public bool missionActive = false;

    public GameObject baloon;

    public AudioSource portalAudio;
    public GameObject batteries;

    public GameObject sonar;

    public GameObject endButtons;

    public TapToPlace placer;

    public bool gameOver = false;

    public bool destroyed = false;

    private AudioSource audioS;

    private static MissionManager instance;

    public static MissionManager Instance
    {
        get{
            return instance;
        }
    }
    private void Awake()
     {
         // if the singleton hasn't been initialized yet
         if (instance != null && instance != this) 
         {
             Destroy(this.gameObject);
         }
 
         instance = this;
         DontDestroyOnLoad( this.gameObject );
     }


    public void FailMission(string mission)
    {
        currentMission = "None";
        missionActive = false;
        if(mission == "Timer Portal")
        {
            placer.village.GetComponent<Buildings>().UnBuild("Timer Portal");

        }
    }

    public void repeatMissionDialogue()
    {
        if(missionActive)
        {
        string[] dialogues = ResearchManager.Instance.getResearchDialogues(currentMission);
        DialogueManager.Instance.startDialogue(dialogues);
        }
    }
    public void ActivateMission(string newMission)
    {
        string[] dialogues = ResearchManager.Instance.getResearchDialogues(newMission);
        DialogueManager.Instance.startDialogue(dialogues);
        missionActive = true;
        currentMission = newMission;
        DebugManager.Instance.ShowDebugText("Activated mission: "+newMission);
        if(currentMission == "Sky Rescue")
        {
            Instantiate(baloon, placer.village.transform.position + new Vector3(Random.Range(-1.5f, 1.5f), 2.0f, Random.Range(-1.5f,1.5f)), transform.rotation);
        }
        else if(currentMission == "Place Sonar")
        {
            Instantiate(sonar, placer.village.transform.position, transform.rotation);
        }
        else if(currentMission == "More Sonars")
        {
            for(int i = 0; i < placer.howManySonars; i++)
            {
                Instantiate(sonar, placer.village.transform.position + Vector3.up * 0.1f*i, transform.rotation);
            }
        }
        else if(currentMission == "Drill Charge")
        {
            Instantiate(batteries, placer.village.transform.position, transform.rotation);
        }
        else if(currentMission == "Energy Tower")
        {
            placer.village.GetComponent<Buildings>().Build("Energy Tower");

        }
        else if(currentMission == "Central Portal")
        {
            placer.village.GetComponent<Buildings>().Build("Central Portal");

        }
        else if(currentMission == "Timer Portal")
        {
            placer.village.GetComponent<Buildings>().Build("Timer Portal");

        }
        else if(currentMission == "RGB Portal")
        {
            placer.village.GetComponent<Buildings>().Build("RGB Portal");

        }
        else if(currentMission == "Right Portal")
        {
            placer.village.GetComponent<Buildings>().Build("Right Portal");

        }
        else if(currentMission == "Final Portal")
        {
            placer.village.GetComponent<Buildings>().Build("Final Portal");

        }
        else if(currentMission == "Lift Drill")
        {
            placer.drillInstance.GetComponent<Drill>().deactivate();
        }
        else if(currentMission == "Broken Sonars")
        {
            for(int i = 0; i < placer.sonars.Count; i++)
            {
                placer.sonars[i].GetComponentInChildren<Sonar>().Break();
            }
        }
        else if(currentMission == "Shake Earth")
        {
            placer.drillInstance.GetComponent<Drill>().StartShakeParticle();
        }

        if(isAPortalOn())
        {
            portalAudio.Play();
        }
        //switch(currentMission)
        
    }

    public bool isAPortalOn()
    {
        if(currentMission == "Central Portal" || currentMission == "Timer Portal" || currentMission == "RGB Portal" || currentMission == "Right Portal" || currentMission == "Final Portal")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CompleteMission(string mission)
    {
        if(mission == currentMission)
        {
                if(isAPortalOn())
                {
                    portalAudio.Stop();
                }
            if(mission == "Final Portal")
            {
                endButtons.SetActive(true);
            }
            else
            {
                audioS.Play();
               if(currentMission == "Shake Earth")
                {
                    placer.drillInstance.GetComponent<Drill>().StopShakeParticle();
                }
                DebugManager.Instance.ShowDebugText("Mission completed: "+ currentMission);
                string[] dialogues = ResearchManager.Instance.getResearchEndDialogues(mission);
                DialogueManager.Instance.startDialogue(dialogues);
                ResearchManager.Instance.completeResearch(currentMission);
                missionActive = false;
                currentMission = "None";
                FeedbackManager.Instance.MissionCompleted();
            }
        }
    }
     private void Start()
     {
         audioS = GetComponent<AudioSource>();
     }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Test");
        if(currentMission == "Broken Sonars")
        {
            bool finished = true;
            for(int i = 0; i < placer.sonars.Count; i++)
            {
                if(!placer.sonars[i].GetComponentInChildren<Sonar>().repaired)
                {
                    finished = false;
                }
            }   
            
            if(finished)
            {
                CompleteMission("Broken Sonars");
            }
        }

        if(gameOver && !DialogueManager.Instance.isOnDialogue)
        {
            if(!destroyed)
            {
                Application.Quit();
            }
        }
    }

    public void DestroyBuildings()
    {
        placer.village.GetComponent<Destroy>().DestroyBuildings();
    }
}
