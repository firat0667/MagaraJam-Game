using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoolDownMEthod : MonoBehaviour
{
    [SerializeField] Image imageCoolDown;

    private bool isCoolDown = false;
    private float time = 0f;
    private float timer = 20f;

    private void Start()
    {
       imageCoolDown.fillAmount = 1f;
    }

    private void Update()
    {
        time += 1f*Time.deltaTime;
        Debug.Log(time);

        imageCoolDown.fillAmount -= time/timer * Time.deltaTime;

        if(time >= timer)
        {
            time = timer;
        }                    
    }
}
