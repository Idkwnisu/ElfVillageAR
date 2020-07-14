using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    public GameObject charger;
    public ParticleSystem shakeParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deactivate()
    {
        charger.GetComponent<CapsuleCollider>().enabled = false;
       // charger.SetActive(false);
    }

    public void StartShakeParticle()
    {
        shakeParticle.Play();
    }

    public void StopShakeParticle()
    {
        shakeParticle.Stop();
    }
}
