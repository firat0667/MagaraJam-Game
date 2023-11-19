using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CoolDownMEthod : MonoBehaviour
{
    [SerializeField] Image imageCoolDown;

        imageCoolDown.fillAmount -= time * Time.deltaTime / timer/2f;

        if (Input.GetKeyDown(KeyCode.E) && lazer.skillavaliable==true) 
        {
        }
    }
    IEnumerator LazerCikartma()
    {
        Lazer.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Lazer.gameObject.SetActive(false);
    }
}
