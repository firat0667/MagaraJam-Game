using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBuyPanel : MonoBehaviour
{
    [SerializeField] Button pistolButton;
    [SerializeField] TextMeshProUGUI ScrapText;
    [SerializeField] GameObject NotEnoughScrapText;



    [SerializeField] TextMeshProUGUI pistolText;
    [SerializeField] TextMeshProUGUI smgText;
    [SerializeField] TextMeshProUGUI shotgunText;
    [SerializeField] TextMeshProUGUI akText;
    [SerializeField] TextMeshProUGUI flameThrowerText;
    [SerializeField] TextMeshProUGUI sniperText;


    //WeaponPrices
    const int pistolPrice = 300;
    const int smgPrice = 400;
    const int shotgunPrice = 500;
    const int akPrice = 700;
    const int flamethrowerPrice = 800;
    const int sniperPrice = 1000;

    private int ScrapCount;

    private bool pistolBought=true;
    private bool smgBought = true;
    private bool akBought = true;
    private bool shotgunBought = true;
    private bool flameThrowerBought = true;
    private bool sniperBought = true;

    void Start()
    {
        ScrapCount = 2000;
       
        //TabCount = 0;
    }

    private void Update()
    {
       // ScrapText.text = ScrapCount.ToString();
    }


    public void buyPistol()
    {
       
        buyWeapon(pistolPrice, pistolText,pistolBought);
        pistolBought = false;
    }

    public void buySmg()
    {
        buyWeapon(smgPrice, smgText,smgBought);
        smgBought = false;
    }
    public void buyShotgun()
    {
        buyWeapon(shotgunPrice, shotgunText,shotgunBought);
        shotgunBought = false;
    }
    public void buyAk()
    {
        buyWeapon(akPrice, akText,akBought);
        akBought = false;
    }
    public void buyFlameThrower()
    {
        buyWeapon(flamethrowerPrice, flameThrowerText,flameThrowerBought);
        flameThrowerBought = false;
    }
    public void buySniper()
    {
        buyWeapon(sniperPrice, sniperText,sniperBought);
        sniperBought = false;
    }

    void buyWeapon(int weaponPrice, TextMeshProUGUI soldText,bool isBought)
    {

        if (isBought)
        {
            if (isEnoughScrap(weaponPrice))
            {

                ScrapCount -= weaponPrice;
                soldText.text = "SOLD!";

            }
        }
        
    }

    bool isEnoughScrap( int improvemntCost)
    {
        if (ScrapCount >= improvemntCost)
            return true;

        else 
        {

            StartCoroutine(notEnoughScrap());
           
            print("Not Enough Scrap!!");
            
            return false;
        }


    }


    IEnumerator notEnoughScrap()
    {
        NotEnoughScrapText.SetActive(true);
        yield return new WaitForSeconds(2);
        NotEnoughScrapText.SetActive(false);

    }
    
   
}
