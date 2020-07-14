using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillLift : MonoBehaviour
{
    public LiftThis[] lifters;
    private SelectableItem item;
    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<SelectableItem>();
    }

    // Update is called once per frame
    void Update()
    {
       if(MissionManager.Instance.currentMission == "Lift Drill")
        {
            if(item.isSelected())
            {
                if(Input.touchCount > 0)
                {
                    if(Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                       
                        bool allLifted = true;
                        for(int i = 0; i < lifters.Length; i++)
                        {
                            if(!lifters[i].lifted)
                            {
                                allLifted = false;
                            }
                        }
                         

                        if(allLifted)
                        {
                            MissionManager.Instance.CompleteMission("Lift Drill");
                            Destroy(gameObject);

                        }
                        
                    }
                }
            }
        }
    }
}
