using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    public MeshRenderer mesh;
    public Material brokenMat;

    public Material offmaterial;

    private bool broken = false;

    private SelectableItem item;

    public bool repaired = false;

    [HideInInspector]
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        item = GetComponent<SelectableItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(broken)
        {
            transform.position = startPosition + 0.01f*new Vector3(Random.Range(0,1f),Random.Range(0,1f),Random.Range(0,1f));
            if(item.isSelected())
            {
                if(Input.touchCount > 0)
                {
                    if(Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        mesh.material = offmaterial;
                        broken = false;
                        repaired = true;
                        GetComponent<AudioSource>().Stop();
                    }
                }
            }
        }
    }

    public void Break()
    {
        mesh.material = brokenMat;
        broken = true;
        GetComponent<AudioSource>().Play();
    }
}
