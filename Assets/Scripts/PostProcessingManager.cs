using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour
{   
    private static PostProcessingManager instance;

    public Image postProcessingOnOff;
    public Image postProcessingBar;

    public float speed = 0.1f;
    public Vector3 offPosition;

    public Vector3 onPosition;
    private bool toOn = false;
    private bool toOff = false;
    public PostProcessVolume volume;
    private bool active = true;
    public static PostProcessingManager Instance
    {
        get{
            return instance;
        }
    }
    public void Activate()
    {
        volume.enabled = true;
        postProcessingBar.color = new Color(0.3f, 0.95f, 1.0f);
        toOn = true;
    }
    public void DeActivate()
    {
        volume.enabled = false;
        postProcessingBar.color = new Color(0.4f, 0.4f, 0.4f);
        toOff = true;
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
    public void Toggle()
    {
        if(!toOn && !toOff)
        {
            active = !active;
            if(active)
            {
                Activate();
            }
            else
            {
                DeActivate();
            }
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(toOn)
        {
            postProcessingOnOff.rectTransform.localPosition = Vector3.Lerp(postProcessingOnOff.rectTransform.localPosition, onPosition,speed);
            if(Vector3.Distance(onPosition, postProcessingOnOff.rectTransform.localPosition) <2.0f)
             {
                 postProcessingOnOff.rectTransform.localPosition = onPosition;
                     toOn = false;
             }   
             Debug.Log(postProcessingOnOff.rectTransform.localPosition);
        }
        else if(toOff)
        {
            postProcessingOnOff.rectTransform.localPosition = Vector3.Lerp(postProcessingOnOff.rectTransform.localPosition, offPosition,speed);
            if(Vector3.Distance(offPosition, postProcessingOnOff.rectTransform.localPosition) < 2.0f)
             {
                 postProcessingOnOff.rectTransform.localPosition = offPosition;
                     toOff = false;
             }
             Debug.Log(postProcessingOnOff.rectTransform.localPosition);
        }
    }
}
