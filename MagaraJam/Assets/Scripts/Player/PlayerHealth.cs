using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Settings")]
    public int health = 100;

    [Header("Elements")]
    public GameObject[] blood_FX;

    private PlayerAnimations playerAnim;

    void Awake()
    {
        playerAnim = GetComponentInParent<PlayerAnimations>();
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
