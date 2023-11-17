using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ImprovementPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScrapText;
    [SerializeField] TextMeshProUGUI NotEnoughScrapText;
    [SerializeField] TextMeshProUGUI HeadLevel;
    [SerializeField] TextMeshProUGUI BodyLevel;
    [SerializeField] TextMeshProUGUI LegLevel;

    const string Level1 = "Level 1";
    const string Level2 = "Level 2";
    const string LevelMax = "MAX";

    private int headLevelCount = 1;
    private int bodyLevelCount = 1;
    private int legLevelCount = 1;

    private int headImprovementCost = 10;
    private int bodyImprovementCost = 10;
    private int legImprovementCost = 10;


    private int ScrapCount;
   


    void Start()
    {
        ScrapCount = 100;       
    }

    // Update is called once per frame
    void Update()
    {
        ScrapText.text = ScrapCount.ToString();
    }

    public void Head_Update()
    {
        headLevelCount++;

        if (headLevelCount == 1)
        {
            
            if (isEnoughScrap(ScrapCount, headImprovementCost))
            {
                HeadLevel.text = Level1;
                ScrapCount -= headImprovementCost;
                headImprovementCost += 20;
            }
        }
        else if (headLevelCount == 2)
        {
           

            if (isEnoughScrap(ScrapCount, headImprovementCost))
            {
                HeadLevel.text = Level2;
                ScrapCount -= headImprovementCost;
                headImprovementCost += 20;
            }
        }
        else if (headLevelCount == 3)
        {
          

            if (isEnoughScrap(ScrapCount, headImprovementCost))
            {
                HeadLevel.text = LevelMax;
                ScrapCount -= headImprovementCost;
             
            }
        }

      
    }

    public void Body_Update()
    {
        bodyLevelCount++;

        if (bodyLevelCount == 1)
        {
         
            if(isEnoughScrap(ScrapCount, bodyImprovementCost))
            {
                BodyLevel.text = Level1;
                ScrapCount -= bodyImprovementCost;
                bodyImprovementCost += 20;
            }
          
        }
        else if (bodyLevelCount == 2)
        {
           

            if (isEnoughScrap(ScrapCount, bodyImprovementCost))
            {
                BodyLevel.text = Level2;
                ScrapCount -= bodyImprovementCost;
                bodyImprovementCost += 20;
            }
        }
        else if (bodyLevelCount == 3)
        {
           
            if (isEnoughScrap(ScrapCount, bodyImprovementCost))
            {
                BodyLevel.text = LevelMax;
                ScrapCount -= bodyImprovementCost;
                bodyImprovementCost += 20;
            }
        }

    }

    public void Leg_Update()
    {
       
        legLevelCount++;

        if (legLevelCount == 1)
        {
            
            if (isEnoughScrap(ScrapCount, legImprovementCost))
            {
                LegLevel.text = Level1;
                ScrapCount -= legImprovementCost;
                legImprovementCost += 20;
            }
        }
        else if (legLevelCount == 2)
        {
           

            if (isEnoughScrap(ScrapCount, legImprovementCost))
            {
                LegLevel.text = Level2;
                ScrapCount -= legImprovementCost;
                legImprovementCost += 20;
            }
        }
        else if (legLevelCount == 3)
        {
       
            if (isEnoughScrap(ScrapCount, legImprovementCost))
            {
                LegLevel.text = LevelMax;
                ScrapCount -= legImprovementCost;
         
            }
        }

       
    }

    bool isEnoughScrap(int ScrapCount,int improvemntCost)
    {
        if (ScrapCount >= improvemntCost)
            return true;

        else        
        {
            print("Not Enough Scrap!!");
    
            return false;
        }
         

    }
}
