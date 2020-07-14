using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacerPreviewer : MonoBehaviour
{
    public GameObject drillPreview;

    public GameObject sonarPreview;
    private static PlacerPreviewer instance;

    public static PlacerPreviewer Instance
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
         DontDestroyOnLoad( this.gameObject );
     }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void drawDrill(Pose position, bool legit)
    {
        if(!drillPreview.activeSelf)
        {
            drillPreview.SetActive(true);
        }
        drillPreview.transform.position = position.position;
        drillPreview.transform.rotation = position.rotation;
        drillPreview.GetComponent<Preview>().setPreview(legit);
    }

    public void deleteDrill()
    {
        drillPreview.SetActive(false);
    }

    public void drawSonar(Vector3 position, bool legit)
    {
        if(!sonarPreview.activeSelf)
        {
            sonarPreview.SetActive(true);
        }
        sonarPreview.transform.position = position;
        sonarPreview.GetComponent<Preview>().setPreview(legit);
    }

    public void deleteSonar()
    {
        sonarPreview.SetActive(false);
    }
}
