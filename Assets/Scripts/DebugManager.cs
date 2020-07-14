using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugManager : MonoBehaviour
{
    public Text debugText;

    private static DebugManager instance;

    public static DebugManager Instance
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

     private void Start()
     {
     }
    void Update()
    {

    }

    public void ShowDebugText(string text)
    {
        debugText.text = text;
    }
}
