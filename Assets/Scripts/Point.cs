using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Point[] connected;
    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Point nextPoint()
    {
        int next = Random.Range(0,connected.Length);
        return connected[next];
    }

     private void OnDrawGizmos()
     {
       Gizmos.color = Color.yellow;
       Gizmos.DrawSphere(transform.position, 0.0015f);
     }
}
