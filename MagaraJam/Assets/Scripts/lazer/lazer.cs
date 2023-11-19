using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class lazer : MonoBehaviour
{
    [SerializeField] GameObject Lazer;
    [SerializeField] Transform pos;
    [SerializeField] CoolDownMEthod CoolDown;
    public static bool skillavaliable = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CoolDown.time >= CoolDown.timer)
        {
            StartCoroutine(LazerCikartma());
            CoolDown.time = 0f;
            skillavaliable = true;
        }
        else
        {
            skillavaliable = false;
        }
    }


    IEnumerator LazerCikartma()
    {                    
        GameObject laser= Instantiate(Lazer, pos.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(laser);
    }
}
