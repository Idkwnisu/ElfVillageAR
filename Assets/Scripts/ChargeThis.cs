using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeThis : MonoBehaviour
{
    public int chargeNeeded = 3;
    private int currentCharges = 0;

    public ParticleSystem effect;

    private SelectableItem item;
    public Material chargedMaterial;

    public GameObject[] charges;
    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<SelectableItem>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<SelectableItem>().isSelected() && HandManager.Instance.currentObject == "Battery")
            {
                     if(MissionManager.Instance.currentMission == "Drill Charge")
                     {
                       charges[currentCharges].GetComponent<MeshRenderer>().material = chargedMaterial;  
                       currentCharges++;
                       effect.Play();
                       GetComponent<AudioSource>().Play();
                       HandManager.Instance.useObject();
                       if(currentCharges >= chargeNeeded)
                       {
                           MissionManager.Instance.CompleteMission("Drill Charge");
                           
                       }
                     }
                    
                
            }
    }
}
