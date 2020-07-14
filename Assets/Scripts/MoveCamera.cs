using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public GameObject cameraToMove;
    public Transform sceneCenter;
    Vector3 startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 relativeCameraPosition = Camera.main.transform.position - transform.position;
        cameraToMove.transform.position = sceneCenter.position + relativeCameraPosition;
        cameraToMove.transform.LookAt(sceneCenter);
        transform.position = startPosition + Vector3.right * Mathf.Sin(Time.time);
    }
}
