using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackManager : MonoBehaviour
{
    private static FeedbackManager instance;

    public static FeedbackManager Instance
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

    public GameObject canvasPicked;

    public Text objectPicked;

    public float timePick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PickedObject(string obj)
    {
        canvasPicked.SetActive(true);
        objectPicked.text = "You picked "+obj;
        Invoke("endPicked",timePick);
    }

    public void MissionCompleted()
    {
         canvasPicked.SetActive(true);
        objectPicked.text = "Mission Completed";
        Invoke("endPicked",timePick);
    }

    public void endPicked()
    {
        canvasPicked.SetActive(false);
        objectPicked.text = "";
    }
}
