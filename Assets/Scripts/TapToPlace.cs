using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;

public class TapToPlace : MonoBehaviour
{
    public GameObject placementIndicator;
    public GameObject toSpawn;

    public GameObject drill;

    public GameObject sonar;

    public GameObject village;

    public List<GameObject> sonars;

    public GameObject drillInstance;

    private bool shakeReady = false;
    private bool touchLocked = false;

    public float shakeDistance = 0.1f;
    
    public int howManyShakes = 4;
    private int shakeCounter = 0;

    public int howManySonars = 3;

    public ARRaycastManager arOrigin;
    private Pose placementPose;
    private bool placementPoseValid;
    private bool placed = false;
    public float drillDistance = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        sonars = new List<GameObject>();
    }


    // Update is called once per frame
    void Update()
    {
        if(!DialogueManager.Instance.isOnDialogue)
        {
        shakeReady = false;

        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if(placed)
        {
            //previews here
            if(MissionManager.Instance.currentMission == "Begin To Dig")
            {
                
                if(Vector3.Distance(placementPose.position, village.transform.position) >= drillDistance)
            {
                PlacerPreviewer.Instance.drawDrill(placementPose,true);
            }
            else
            {
                 PlacerPreviewer.Instance.drawDrill(placementPose,false);
                 
            }
            }

            if(MissionManager.Instance.currentMission == "Place Sonar" || MissionManager.Instance.currentMission == "More Sonars")
            {
                if(HandManager.Instance.currentObject == "Sonar")
                {

                    PlacerPreviewer.Instance.drawSonar(Camera.main.transform.position + Camera.main.transform.forward * 1,true);

                }
            }

        if(Input.touchCount > 0)
        {   
            
            if(Input.touches[0].phase == TouchPhase.Began)
           {
               if(placementPoseValid)
            {
            if(MissionManager.Instance.currentMission == "Begin To Dig")
            {
            if(Vector3.Distance(placementPose.position, village.transform.position) >= drillDistance)
            {
                drillInstance = Instantiate(drill, placementPose.position, placementPose.rotation);
                MissionManager.Instance.CompleteMission("Begin To Dig");
                PlacerPreviewer.Instance.deleteDrill();
            }
            }
           }
            
            if(MissionManager.Instance.currentMission == "Place Sonar" && HandManager.Instance.currentObject == "Sonar")
            {
                sonars.Add(Instantiate(sonar, Camera.main.transform.position + Camera.main.transform.forward * 1, transform.rotation));
                PlacerPreviewer.Instance.deleteSonar();
                HandManager.Instance.useObject();
                MissionManager.Instance.CompleteMission("Place Sonar");
            }
            else if(MissionManager.Instance.currentMission == "More Sonars" && HandManager.Instance.currentObject == "Sonar")
            {
                sonars.Add(Instantiate(sonar, Camera.main.transform.position + Camera.main.transform.forward * 1, transform.rotation));
                PlacerPreviewer.Instance.deleteSonar();
                HandManager.Instance.useObject();
                howManySonars--;
                if(howManySonars <= 0)
                    MissionManager.Instance.CompleteMission("More Sonars");
            }
            }
           
            }
            if(MissionManager.Instance.currentMission == "Shake Earth" && shakeReady)
            {
                if(Input.touchCount > 0)
                {
                  if(Input.touches[0].phase == TouchPhase.Began)
                {
                        shakeCounter++;
                        drillInstance.GetComponent<DrillShake>().startShake(0.1f);
                        shakeReady = false;
                        if(shakeCounter >= howManyShakes)
                        {
                            MissionManager.Instance.CompleteMission("Shake Earth");
                        }
                }  
                }
            }
            
        }
        }
    }

    private void UpdatePlacementIndicator()
    {
        if(placementPoseValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        List<ARRaycastHit> hits1 = new List<ARRaycastHit>();
        List<ARRaycastHit> hits2 = new List<ARRaycastHit>();
        List<ARRaycastHit> hits3 = new List<ARRaycastHit>();
        arOrigin.Raycast(screenCenter, hits1,UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        arOrigin.Raycast(screenCenter + new Vector3(0.1f, 0.1f,0.1f), hits2,UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        arOrigin.Raycast(screenCenter - new Vector3(0.1f, 0.1f,0.1f), hits3,UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        placementPoseValid = hits1.Count > 0 && hits2.Count > 0 && hits3.Count > 0;
        if(placementPoseValid)
        {
            placementPose = hits1[0].pose;
            if(placed == false)
            {
                if(Input.touchCount > 0)
                {
                  if(Input.touches[0].phase == TouchPhase.Began)
                {
                placed = true;
                village = Instantiate(toSpawn, hits1[0].pose.position, hits1[0].pose.rotation);
                 arOrigin.gameObject.GetComponent<ARPlaneManager>().enabled = false;
                }
                }
               
            }
        }

         if(Input.touchCount > 0)
        {
             if(Input.touches[0].phase == TouchPhase.Began)
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                Ray ray = Camera.current.ScreenPointToRay(Input.touches[0].position);
                arOrigin.Raycast(Input.touches[0].position, hits);
                if(hits.Count > 0)
                {

                if(MissionManager.Instance.currentMission == "Shake Earth")
                {
                    if(Vector3.Distance(hits1[0].pose.position, drillInstance.transform.position) < drillDistance)
                    {
                      shakeReady = true;
                     }
                 }
                }
            }
        }
    }
}
