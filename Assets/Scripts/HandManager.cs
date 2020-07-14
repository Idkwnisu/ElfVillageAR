using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour
{

    public string currentObject = "None";

    public Text debugText;
    private static HandManager instance;


    public Image image;

    public Sprite sonarSprite;
    public Sprite batterySprite;
    public Sprite emptySprite;

    private AudioSource audioS;

    public static HandManager Instance
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
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public bool hasObject()
    {
        return currentObject != "None";
    }

    public bool pickUpObject(string obj)
    {
        if(currentObject != "None")
            return false;
        else
        {
            image.color = new Color(1,1,1,1);
            currentObject = obj;
             FeedbackManager.Instance.PickedObject(obj);
            if(obj == "Sonar")
            {
                image.sprite = sonarSprite;
            }
            else if(obj == "Battery")
            {
                image.sprite = batterySprite;
            }
            audioS.Play();
            return true;
           
        }
    }

    public void useObject()
    {
        currentObject = "None";
        image.sprite = null;
        image.color = new Color(1,1,1,0);
    }
}
