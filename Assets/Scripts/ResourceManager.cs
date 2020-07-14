using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager instance;

    public Text leftText;
    public Text rightText;
    public static ResourceManager Instance
    {
        get{
            return instance;
        }
    }

    public float Money;
    public float Food;

    public float Technology;

    public float Happiness;

    public float Magic;
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
        Money = 0;
        Food = 0;
        Technology = 0;
        Happiness = 0;   
        Magic = 0;
    }


    public float GetMoney()
    {
        return Money;
    }

    public float getFood()
    {
        return Food;
    }

    public float getTechnology()
    {
        return Technology;
    }

    public float getMagic()
    {
        return Magic;
    }

    public float getHappiness()
    {
        return Happiness;
    }

    public void gainMoney(float amount)
    {
        Money += amount;
        UpdateUI();
    }

    public void gainFood(float amount)
    {
        Food += amount;
        UpdateUI();
    }

    public void gainHappiness(float amount)
    {
        Happiness += amount;
        UpdateUI();
    }

    public void gainMagic(float amount)
    {
        Magic += amount;
        UpdateUI();
    }

    public void gainTechnology(float amount)
    {
        Technology += amount;
        UpdateUI();
    }

    public void UpdateUI()
    {
        leftText.text = "Money: "+Money+"\nTechnology: "+Technology+"\nMagic: "+Magic;
        rightText.text = "Food: "+Food+"\nHappiness: "+Happiness;
    }
    // Update is called once per frame
    void Update()
    {
        gainTechnology(1);
        gainHappiness(1);
    }
}
