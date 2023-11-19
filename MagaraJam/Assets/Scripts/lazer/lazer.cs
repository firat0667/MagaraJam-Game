using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class lazer : MonoBehaviour
{
    [SerializeField] GameObject Lazer;
    [SerializeField] Transform pos;
    [SerializeField] CoolDownMEthod CoolDown;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CoolDown.skillAvaliable==true)
        {
            StartCoroutine(LazerCikartma());
            CoolDown.time = 0f;
            
        }
    }


    IEnumerator LazerCikartma()
    {
        Lazer.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Lazer.gameObject.SetActive(false);
    }
}
