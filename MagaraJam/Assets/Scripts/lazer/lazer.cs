using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class lazer : MonoBehaviour
{
    [SerializeField] GameObject Lazer;
    [SerializeField] Transform pos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(LazerCikartma());
        }
    }


    IEnumerator LazerCikartma()
    {
        GameObject laser= Instantiate(Lazer, pos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(laser);
    }
}
