using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActivateCentered : MonoBehaviour
{

    public Text debug;
    private ObjectToActivateResearch lastBuilding = null;
    private SelectableItem lastItem;

    public Image cursor;
    private GameObject lastSelectedObject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!DialogueManager.Instance.isOnDialogue)
            UpdateActivation();
        else
        {
            cursor.color = Color.white;
            cursor.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
        }
    }

    public void UpdateActivation()
    {
        LayerMask lm = LayerMask.GetMask("Plane");
        lm = ~lm;
        RaycastHit hit;
        Camera camera = Camera.main;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward,out hit, Mathf.Infinity, lm))
            {
                if(hit.transform.gameObject.tag == "Building")
            {  
                if(lastBuilding!=null)
                    if(lastBuilding.gameObject.name != hit.transform.gameObject.name)
                        lastBuilding.DeActivate();
                lastBuilding =  hit.transform.gameObject.GetComponent<ObjectToActivateResearch>();
                lastBuilding.Activate();
            }
            else
            {
                if(lastBuilding != null)
                    lastBuilding.DeActivate();
                lastBuilding = null;
                cursor.color = Color.white;
                cursor.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
            }
            
            }
            else
            {
                if(lastBuilding != null)
                lastBuilding.DeActivate();
            lastBuilding = null;
            cursor.color = Color.white;
            cursor.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
            }
        if(Input.touchCount > 0)
        {   
            
        if(Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = camera.ScreenPointToRay(Input.touches[0].position);
            
        if(Physics.Raycast(ray,out hit, Mathf.Infinity, lm))
        {
             if(hit.transform.gameObject.tag == "Activable")
            {
                if(lastItem!=null)
                    if(lastItem.gameObject.name != hit.transform.gameObject.name)
                        lastItem.Unselect();
                lastItem =  hit.transform.gameObject.GetComponent<SelectableItem>();
                lastItem.Select();

                cursor.color = Color.red;
                cursor.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            }
            else
            {

                cursor.color = Color.white;
                cursor.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
            }
        }
        else
        {
            if(lastItem != null)
                {
                        lastItem.Unselect();
                    }
            cursor.color = Color.white;
            cursor.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
        }
        }
        }
    }
}
