using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTimerManager : MonoBehaviour
{
    public Text timer;
    public GameObject toAct;

     private static GameOverTimerManager instance;

     private float remainingTime;

     private float startTime;

    private bool timerActive; 

    public bool timerOver = false;

     public static GameOverTimerManager Instance
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

    public void setTimer(float time)
    {
        timerOver = false;
        toAct.gameObject.SetActive(true);
        startTime = Time.time;
        timerActive = true;
        remainingTime = time;
    }

    public void defuse()
    {
        timerActive = false;
        toAct.gameObject.SetActive(false);
        timerOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive)
        {
            timer.text = " "+(remainingTime-(Time.time-startTime));
           if(Time.time-startTime >= remainingTime)
           {
               timerOver = true;
           }
        }
    }
}
