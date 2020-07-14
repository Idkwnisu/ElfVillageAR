using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionActivator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateMissionOne()
    {
        MissionManager.Instance.ActivateMission(ResearchManager.Instance.firstRes.name);
    }

    

    public void ActivateMissionTwo()
    {
        MissionManager.Instance.ActivateMission(ResearchManager.Instance.secondRes.name);
    }
}
