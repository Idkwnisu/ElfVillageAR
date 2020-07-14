using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class Tween : MonoBehaviour
{
    public Vector3 targetScale;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale( this.gameObject,targetScale, time).setEase(LeanTweenType.easeOutBounce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
