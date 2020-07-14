using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerRotation : MonoBehaviour
{
    public GameObject inner;
    public GameObject outer;

    public Gear[] gears;

    public float HowMuchTime;

    public float gearSpeed = 3.0f;

    private bool startedUp = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(startedUp)
        {
            outer.transform.Rotate(new Vector3(0.0f,0.0f,Time.deltaTime/HowMuchTime*360*4));
            inner.transform.Rotate(new Vector3(0.0f,0.0f,Time.deltaTime/HowMuchTime*360));

            for(int i = 0; i < gears.Length; i++)
            {
                if(gears[i].right)
                {
                    gears[i].transform.Rotate(new Vector3(0.0f,0.0f,Time.deltaTime/HowMuchTime*360*gearSpeed));
                }
                else
                {
                    gears[i].transform.Rotate((-1)*new Vector3(0.0f,0.0f,Time.deltaTime/HowMuchTime*360*gearSpeed));
                }
            }
        }
    }

    public void startUp(float time)
    {
        startedUp = true;
        HowMuchTime = time;
    }
}
