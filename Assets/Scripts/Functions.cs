using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    public Choice[] cityChoices;
    public Choice[] researchChoices;
    public Choice[] explorationChoices;

    public bool cityChoiceCompleted = false;
    public bool researchChoiceCompleted = false;
    public bool explorationChoiceCompleted = false;

    public Material first;
    public Material second; 

    public GameObject cylinder;

    private static Functions _instance;

    public static Functions Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Functions>();
            }

            return _instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFirstMaterialCity()
    {
        cylinder.GetComponent<MeshRenderer>().material = first;
        cityChoiceCompleted = true;
    }

    public void SetSecondMaterialCity()
    {
        cylinder.GetComponent<MeshRenderer>().material = second;
        cityChoiceCompleted = true;
    }

    public void SetFirstMaterialExploration()
    {
        cylinder.GetComponent<MeshRenderer>().material = first;
        explorationChoiceCompleted = true;
    }

    public void SetSecondMaterialExploration()
    {
        cylinder.GetComponent<MeshRenderer>().material = second;
        explorationChoiceCompleted = true;
    }

     public void SetFirstMaterialResearch()
    {
        cylinder.GetComponent<MeshRenderer>().material = first;
        researchChoiceCompleted = true;
    }

    public void SetSecondMaterialResearch()
    {
        cylinder.GetComponent<MeshRenderer>().material = second;
        researchChoiceCompleted = true;
    }


    public Choice getRandomCityChoice()
    {
        int index = Random.Range(0, cityChoices.Length);
        cityChoiceCompleted = false;
        return cityChoices[index];
    }

    public Choice getRandomResearchChoice()
    {
        int index = Random.Range(0, researchChoices.Length);
        researchChoiceCompleted = false;
        return researchChoices[index];
        
    }

    public Choice getRandomExplorationChoice()
    {
        int index = Random.Range(0, explorationChoices.Length);
        explorationChoiceCompleted = false;
        return explorationChoices[index];
    }
}
