using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrollingPoints : MonoBehaviour
{
    public Point nextPoint;
    public float speed;
    public float distance;

    private bool scared = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MissionManager.Instance.isAPortalOn())
        {
            if(scared == false)
            {
                GetComponentInChildren<Animator>().SetBool("GetScared",true);
                scared = true;
            }
        }
        else
        {
            if(scared)
            {
                GetComponentInChildren<Animator>().SetBool("GetScared",false);
                scared = false;
            }
            if(Vector3.Distance(transform.position, nextPoint.position) < distance)
            {
                nextPoint = nextPoint.nextPoint();
            }
            else
            {
                Vector3 movement = nextPoint.position - transform.position;
                movement = movement.normalized;
                movement = movement*speed*Time.deltaTime;
                transform.LookAt(transform.position + movement);
                transform.position += movement;
            }
        }
    }
}
