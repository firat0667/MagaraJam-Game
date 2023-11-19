using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CoolDownMEthod : MonoBehaviour
{
    [SerializeField] Image imageCoolDown;
    public float time = 0f;
    private float timer = 4f;
    public bool skillAvaliable = false;

    private void Start()
    {
       imageCoolDown.fillAmount = 1f;
    }

    private void Update()
    {
        time += 1f * Time.deltaTime;
        Debug.Log(time);

        imageCoolDown.fillAmount -= time * Time.deltaTime / timer/2;

        if(time >= timer)
        {
            time = timer;
            skillAvaliable = true;

        }
        if (time < timer)
        {
            skillAvaliable = false;
        }


        if (Input.GetKeyDown(KeyCode.E) && skillAvaliable == true) 
        {
           imageCoolDown.fillAmount = 1f;

        }
    }
}
