using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverItem : MonoBehaviour
{
    public string MissionToFinish = "Sky Rescue";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MissionManager.Instance.missionActive )
        {
            if(GetComponent<SelectableItem>().isSelected())
            {
               
                     if(MissionManager.Instance.currentMission == MissionToFinish)
                     {
                     MissionManager.Instance.CompleteMission(MissionToFinish);
                     Destroy(gameObject);
                     }
                    
                
            }
        }
    }
}
