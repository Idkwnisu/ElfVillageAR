using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleColorGuess : MonoBehaviour
{
    public ColorSelector[] colors;
     private SelectableItem item;

    public Material deactivatedMat;
    public Material failedMat;

    private Material normal;
    public string MissionToEnd;

    private bool going = true;

    public Image white;

    public MeshRenderer[] rend;
    // Start is called before the first frame update
    void Start()
    {
         item = GetComponent<SelectableItem>(); 
         
         normal = rend[0].material;

    }

    // Update is called once per frame
    void Update()
    {
        if(going)
        {
        if(item.isSelected())
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Began)
                {
                    bool correct = true;
                    for(int i = 0; i < colors.Length; i++)
                    {
                        if(!colors[i].isCorrect())
                        {
                            correct = false;
                        }
                    }
                    if(correct)
                    {
                        for(int i = 0; i < rend.Length; i++)
                        {
                            rend[i].material = deactivatedMat;
                        }
                        MissionManager.Instance.CompleteMission(MissionToEnd);
                        going = false;
                    }
                    else
                    {
                        for(int i = 0; i < rend.Length; i++)
                        {
                            rend[i].material = failedMat;
                        }
                        Invoke("Fail", 0.3f);
                    }
                }

            }
        }
        }
        if(MissionManager.Instance.gameOver && MissionManager.Instance.destroyed)
        {
            if(!white.gameObject.activeSelf)
            {
                white.gameObject.SetActive(true);
            }
            for(int i = 0; i < rend.Length; i++)
            {               
                rend[i].material = normal;
            }

            for(int i = 0; i < rend.Length; i++)
            {               
                rend[i].gameObject.transform.localScale *= 1.02f;
            }
            
            white.color = new Color(1,1,1,Mathf.Min(white.color.a + 0.01f,1.0f)); 

            if(rend[0].gameObject.transform.localScale.x > 4.0f)
            {
                 white.gameObject.SetActive(false);
                 rend[0].gameObject.SetActive(false);
                            
                MissionManager.Instance.DestroyBuildings();
                 //CHANGE MESHES HERE
            }
        }
    }

    public void Fail()
    {
        for(int i = 0; i < rend.Length; i++)
        {               
            rend[i].material = normal;
        }
        for(int i = 0; i < colors.Length; i++)
        {
            colors[i].ResetMaterial();          
            
        }
    }
}
