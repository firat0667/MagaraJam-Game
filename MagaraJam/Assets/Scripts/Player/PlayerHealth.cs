using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Settings")]
    public int health = 100;

    [Header("Elements")]
    public GameObject[] blood_FX;

    private PlayerAnimations playerAnim;
    public Slider Slider;
    public static PlayerHealth Instace;

    void Awake()
    {
        if (Instace == null)
            Instace = this;
        else
            Destroy(gameObject); 

        playerAnim = GetComponentInParent<PlayerAnimations>();
    }
    private void Start()
    {
        Slider.maxValue = 100;
        Slider.minValue = 0;
    }
    private void Update()
    {
        Slider.value = health;
    }

    public void DealDamage(int damage)
    {

        health -= damage;

        GameplayController.instance.PlayerLifeCounter(health);

        //playerAnim.Hurt();

        if (health <= 0)
        {

            GameplayController.instance.PlayerAlive = false;

            GetComponent<Collider2D>().enabled = false;
            playerAnim.Dead();

            blood_FX[Random.Range(0, blood_FX.Length)].SetActive(true);

            GameplayController.instance.GameOver();

        }

    }
}
