using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CoolDownMEthod : MonoBehaviour
{
    [SerializeField] Image imageCoolDown;
    public float time = 4f;
    public float timer = 4f;
    private void Update()
    {
        time += 1f * Time.deltaTime;

        imageCoolDown.fillAmount -= time * Time.deltaTime / timer/2f;

        if (Input.GetKeyDown(KeyCode.E) && lazer.skillavaliable==true) 
        {
            imageCoolDown.fillAmount = 1f;
        }
    }
}
