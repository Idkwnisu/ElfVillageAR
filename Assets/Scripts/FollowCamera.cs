using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPlane = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(transform.position - (cameraPlane - transform.position));

        if(MissionManager.Instance.missionActive)
        {
            gameObject.SetActive(false);
        }
    }
}
