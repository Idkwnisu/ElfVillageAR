using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    private Vector3 position;

    public Vector3 direction;
    public float frequency;

    public float delay = 0.0f;

    public bool start = false;
    public float amount;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Save", delay);
    }

    void Save()
    {
        position = transform.position;
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        transform.position = position + direction * Mathf.Sin(Time.fixedTime * frequency)*amount;
    }
}
