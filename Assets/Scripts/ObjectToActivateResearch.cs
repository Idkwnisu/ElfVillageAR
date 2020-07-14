using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectToActivateResearch : MonoBehaviour
{
    public Material defaultMat;
    public Material activatedMat;

    private Choice choice;

    private bool researchesReady = false;

    public GameObject billboard;
    public GameObject toActivate;

    public GameObject toActivateOnly;
    
    public Button firstResearch;
    public Button secondResearch;

    public Button onlyResearch;

    // Update is called once per frame
    void Update()
    {
        if(MissionManager.Instance.missionActive)
        {
            DeActivate();
        }
    }


    public void Activate()
    {
        if(!MissionManager.Instance.missionActive)
        {
        GetComponent<MeshRenderer>().material = activatedMat;
        if(ResearchManager.Instance.onlyOneRes)
        {
            toActivateOnly.SetActive(true);
            onlyResearch.GetComponentInChildren<Text>().text = ResearchManager.Instance.firstRes.res_name;
        }
        else
        {
            toActivate.SetActive(true);
            firstResearch.GetComponentInChildren<Text>().text = ResearchManager.Instance.firstRes.res_name;
            secondResearch.GetComponentInChildren<Text>().text = ResearchManager.Instance.secondRes.res_name;
        }
        }
    }
    public void DeActivate()
    {
        GetComponent<MeshRenderer>().material = defaultMat;
        toActivate.SetActive(false);
        toActivateOnly.SetActive(false);
        
    }


}
