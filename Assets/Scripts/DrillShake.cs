using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillShake : MonoBehaviour
{
    private Vector3 startPosition;

    private bool shake = false;

    public float amount = 0.005f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(shake)
        {
            transform.position += new Vector3(Random.Range(-amount,amount),Random.Range(-amount,amount),Random.Range(-amount,amount));
        }
    }

    public void startShake(float timer)
    {
        shake = true;
        Invoke("stopShake",timer);
    }

    public void stopShake()
    {
        shake = false;
        transform.position = startPosition;
    }
}
