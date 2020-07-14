using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectToActivateChoices : MonoBehaviour
{
    public Material defaultMat;
    public Material activatedMat;

    private Choice choice;

    public GameObject billboard;

    private bool choiceAvailable = false;

    public float time;

    public enum Type{City, Research, Exploration}

    public Type buildingType;
    public GameObject toActivate;

    public Button firstChoice;
    public Button secondChoice;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("fetchChoice", time);
    }

    // Update is called once per frame
    void Update()
    {
        if(choiceAvailable)
        {
            switch(buildingType)
        {
            case Type.City:
                if(Functions.Instance.cityChoiceCompleted)
                 {
                        choiceAvailable = false;
                        billboard.GetComponent<MeshRenderer>().material = defaultMat;
                        Invoke("fetchChoice", time);
                 }
            break;
            case Type.Research:
                if(Functions.Instance.researchChoiceCompleted)
                 {
                     choiceAvailable = false;
                     billboard.GetComponent<MeshRenderer>().material = defaultMat;
                     Invoke("fetchChoice", time);
                 }   
            break;
            case Type.Exploration:
                if(Functions.Instance.explorationChoiceCompleted)
                 {
                     choiceAvailable = false;
                     billboard.GetComponent<MeshRenderer>().material = defaultMat;
                     Invoke("fetchChoice", time);
                 }
            break;
        }
        }
    }

    public void fetchChoice()
    {
        switch(buildingType)
        {
            case Type.City:
                choice = Functions.Instance.getRandomCityChoice();
            break;
            case Type.Research:
                choice = Functions.Instance.getRandomResearchChoice();
            break;
            case Type.Exploration:
                choice = Functions.Instance.getRandomExplorationChoice();
            break;
        }
        choiceAvailable = true;
        billboard.GetComponent<MeshRenderer>().material = activatedMat;
    }

    public void Activate()
    {
        if(choiceAvailable)
        {
        GetComponent<MeshRenderer>().material = activatedMat;
        toActivate.SetActive(true);
        firstChoice.onClick.AddListener(FirstButton);
        secondChoice.onClick.AddListener(SecondButton);
        firstChoice.GetComponentInChildren<Text>().text = choice.firstChoice;
        secondChoice.GetComponentInChildren<Text>().text = choice.secondChoice;
        }
    }

    public void FirstButton()
    {
        Functions.Instance.Invoke(choice.firstChoiceEvent,0.0f);
    }

    public void SecondButton()
    {
        Functions.Instance.Invoke(choice.secondChoiceEvent,0.0f);
    }

    public void DeActivate()
    {
        GetComponent<MeshRenderer>().material = defaultMat;
        toActivate.SetActive(false);
        
    }


}
