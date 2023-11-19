using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddWeapons : MonoBehaviour
{
    // Start is called before the first frame update
    public int index;
    public int ScrapPrice;
    public GameObject LazerAbility;
    public TextMeshProUGUI PriceText;
  
    private void Awake()
    {
        PriceText.text=ScrapPrice.ToString();
    }
    public void AddWeapon()
    {
        if (GameplayController.instance.CoinValue > ScrapPrice)
        {
            GameplayController.instance.CollectGold(-ScrapPrice);
            WeaponManager.instance.Weapons_Unlocked.Add(WeaponManager.instance.Total_Weapons[index]);
        }

    }
    public void Lazer()
    {
        if (GameplayController.instance.CoinValue > ScrapPrice)
        {
            LazerAbility.SetActive(true);
        }
       
    }
    public void Hp()
    {
        if (GameplayController.instance.CoinValue > ScrapPrice)
        {
            PlayerHealth.Instace.health += 25;
        }
    }
}
