using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftThis : MonoBehaviour
{
    public GameObject toLift;
    private SelectableItem item;
    public bool lifted = false;

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
                        lifted = true;
                        toLift.SetActive(false);
                        GetComponent<Collider>().enabled = false;
                    }
                }
            }
        }
    }
}
