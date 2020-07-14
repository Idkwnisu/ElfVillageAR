using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchManager : MonoBehaviour
{
    private Dictionary<string,Research> completedResearches;
    private Dictionary<string,Research> uncompletedResearches;

    public Research[] researches;

    public Research firstRes;

    public Research secondRes;

    public bool onlyOneRes = false;

    private static ResearchManager instance;

    public static ResearchManager Instance
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
         
         uncompletedResearches = new Dictionary<string, Research>();
         completedResearches = new Dictionary<string, Research>();

             for(int i = 0; i < researches.Length; i++)
             {
                 uncompletedResearches.Add(researches[i].res_name, researches[i]);
             }

         extractResearches();
         DontDestroyOnLoad( this.gameObject );
     }

     private void Start()
     {
     }

    public List<Research> getNextResearches()
    {
        List<Research> toReturn = new List<Research>();

        foreach(KeyValuePair<string, Research> res in uncompletedResearches)
        {
            if(!checkBlockedCompletion(res.Value))
            {
                if(checkRequisitesCompletion(res.Value))
                {
                    toReturn.Add(res.Value);
                }
            }
        }
        return toReturn;
    }

    public int checkBonusCompletion(Research res)
    {
        int acc = 0;
        for(int i = 0; i < res.malus.Length; i++)
        {
            if(checkIfCompleted(res.malus[i].res_name))
            {
                acc -= 1;
            }
        }

        for(int i = 0; i < res.bonus.Length; i++)
        {
            if(checkIfCompleted(res.bonus[i].res_name))
            {
                acc += 1;
            }
        }
        return acc;
    }

    public bool checkBlockedCompletion(Research res)
    {
        for(int i = 0; i < res.blocked.Length; i++)
        {
            if(!checkIfCompleted(res.blocked[i].res_name))
            {
                return true;
            }
        }
        return false;
    }

    public bool checkRequisitesCompletion(Research res)
    {
        for(int i = 0; i < res.requisites.Length; i++)
        {
            if(!checkIfCompleted(res.requisites[i].res_name))
            {
                return false;
            }
        }
        return true;
    }
    public bool checkIfCompleted(string research)
    {
        return completedResearches.ContainsKey(research);
    }

    private void extractResearches()
    {
        List<Research> researchesAvailable = ResearchManager.Instance.getNextResearches();
                if(researchesAvailable.Count > 1)
                {
                    onlyOneRes = false;
               int max1 = -1000;
               int max2 = -1000;
               for (int i = 0; i < researchesAvailable.Count; i++)
               {
                   if(max1 == -1000)
                   {
                       firstRes = researchesAvailable[i];
                       max1 = ResearchManager.Instance.checkBonusCompletion(researchesAvailable[i]);
                   }
                   else if(max2 == -1000)
                   {
                       secondRes = researchesAvailable[i];
                       max2 = ResearchManager.Instance.checkBonusCompletion(researchesAvailable[i]);
                   }
                   else if(ResearchManager.Instance.checkBonusCompletion(researchesAvailable[i]) > max1)
                   {
                       firstRes = researchesAvailable[i];
                       max1 = ResearchManager.Instance.checkBonusCompletion(researchesAvailable[i]);
                   }
                   else if(ResearchManager.Instance.checkBonusCompletion(researchesAvailable[i]) > max1)
                   {
                       secondRes = researchesAvailable[i];
                       max2 = ResearchManager.Instance.checkBonusCompletion(researchesAvailable[i]);
                   }
               }
                }
                else
                {
                    onlyOneRes = true;
                    firstRes = researchesAvailable[0];
                }
    }

    public void completeResearch(Research research)
    {
        uncompletedResearches.Remove(research.res_name);
        completedResearches.Add(research.res_name, research);

         extractResearches();
    }

    public void completeResearch(string mission)
    {
        completedResearches.Add(mission, uncompletedResearches[mission]);
        uncompletedResearches.Remove(mission);

         extractResearches();
    }

    public string[] getResearchDialogues(string mission)
    {
        return uncompletedResearches[mission].dialogues;
    }

    public string[] getResearchEndDialogues(string mission)
    {
        return uncompletedResearches[mission].endDialogues;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
