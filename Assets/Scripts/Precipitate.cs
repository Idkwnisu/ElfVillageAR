using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Precipitate : MonoBehaviour
{
    public float startSpeed = 0.0f;
    public float speedAugment = 0.1f;

    public float timeEnd = 1.5f;
    public float timeBegin = 1.0f;

    private bool ended = true;

    public Vector3 direction;

    public ParticleSystem[] effects;
    public GameObject[] toActivate;

    public float maxOffset = 0.2f;
    private float augment = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Begin",timeBegin);
    }

    // Update is called once per frame
    void Update()
    {
        if(!ended && augment < maxOffset)
        {
        augment += startSpeed;
        if(augment > maxOffset)
        {
            End();
        }
        transform.position += direction*startSpeed;
        startSpeed += speedAugment;
        }
    }
    
    void Begin()
    {
        ended = false;
        Invoke("End",timeEnd);
    }
    void End()
    {
        if(!ended)
        {
        ended = true;
        for(int i = 0; i < effects.Length; i++)
        {
            effects[i].Play();
        }
        GetComponent<AudioSource>().Play();

        for(int i = 0; i < toActivate.Length; i++)
        {
            toActivate[i].SetActive(true);
        }
        }
    }
}
