using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{   
    public bool isOnDialogue = false;
    public string[] dialoges;

    public int currentDialogue;
    public int currentLetter;

    public float howMuchTimeLetter = 0.1f;

    
    public Sprite male;
    public Sprite female;

    public Image dialogue;

    public Text display;

    public GameObject goOnArrow;

    public GameObject textBox;

    public float lastLetter = 0;

    private bool isWriting = false;

    private AudioSource blip;

    
private static DialogueManager instance;

    public static DialogueManager Instance
    {
        get{
            return instance;
        }
    }

    private void Awake()
     {
         // if the singleton hasn't been initialized yet
         if (instance != null && instance != this) 
         {
             Destroy(this.gameObject);
         }
 
         instance = this;
         
        
         DontDestroyOnLoad( this.gameObject );
     }

    // Start is called before the first frame update
    void Start()
    {
        blip = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isOnDialogue)
        {
            if(isWriting)
            {
                if(Input.touchCount > 0)
                {
                    if(Input.touches[0].phase == TouchPhase.Began)
                    {
                        for(; currentLetter < dialoges[currentDialogue].Length; currentLetter++)
                        {
                            display.text += dialoges[currentDialogue][currentLetter];
                            isWriting = false;
                        }
                        goOnArrow.SetActive(true);
                    }
                }
                if(Time.time - lastLetter > howMuchTimeLetter && isWriting)
                {
                    display.text += dialoges[currentDialogue][currentLetter];
                    blip.Play();
                    lastLetter = Time.time;
                    currentLetter++;
                    if(currentLetter >= dialoges[currentDialogue].Length)
                    {
                        isWriting = false;
                        goOnArrow.SetActive(true);
                    }
                }
            }
            else
            {
                 if(Input.touchCount > 0)
                {
                    if(Input.touches[0].phase == TouchPhase.Began)
                    {
                        currentDialogue++;
                        if(currentDialogue >= dialoges.Length)
                        {
                            stopDialogue();
                        }
                        else
                        {
                            goOnArrow.SetActive(false);
                            display.text = "";
                            isWriting = true;
                            currentLetter = 0;
                        }
                    }
                }
                else if(Input.GetKeyDown(KeyCode.A))
                {
                    currentDialogue++;
                        if(currentDialogue >= dialoges.Length)
                        {
                            stopDialogue();
                        }
                        else
                        {
                            goOnArrow.SetActive(false);
                            display.text = "";
                            isWriting = true;
                            currentLetter = 0;
                        }
                }
            }
            
        }
        
    }

   public void stopDialogue()
    {
        textBox.SetActive(false);
        isOnDialogue = false;
    }

   public void startDialogue(string[] dialogues)
    {
        textBox.SetActive(true);
        goOnArrow.SetActive(false);
        if(Random.Range(0,10) > 5)
        {
            dialogue.sprite = male;
        }
        else
        {
            dialogue.sprite = female;
        }
        display.text = "";
        this.dialoges = dialogues;
        isOnDialogue = true;
        isWriting = true;
        currentDialogue = 0;
        currentLetter = 0;
    }
}
