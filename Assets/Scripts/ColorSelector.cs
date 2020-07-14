using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelector : MonoBehaviour
{
    public Material[] materials;
    public GameObject signaler;

    public int correctGuess;
    private int currentGuess = 0;
    // Start is called before the first frame update
    void Start()
    {
      updateMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isCorrect()
    {
        return currentGuess == correctGuess;
    }
    public void nextMat()
    {
        currentGuess++;
        if(currentGuess >= materials.Length)
        {
            currentGuess = 0;
        }
        updateMaterial();
    }

    public void previousMat()
    {
        currentGuess--;
        if(currentGuess <= 0)
        {
            currentGuess = materials.Length-1;
        }
        updateMaterial();
    }

    public void updateMaterial()
    {
          signaler.GetComponent<MeshRenderer>().material = materials[currentGuess];
    }

    public void ResetMaterial()
    {
        currentGuess = 0;
        updateMaterial();
    }
}
