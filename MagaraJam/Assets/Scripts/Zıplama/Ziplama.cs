using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ziplama : MonoBehaviour
{
    [SerializeField] ZiplamaBari ZiplamaBari;
    [SerializeField] Rigidbody2D rigidbody2;
    float ZiplamaSeviyesi;
    private void Start()
    {
        ZiplamaBari = GetComponent<ZiplamaBari>();
    }
    private void Update()
    {
        ZiplamaSeviyesi = ZiplamaBari.ZiplamaSeviyesi;
    }
    public void jump()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            rigidbody2.AddForce(new Vector2(0, ZiplamaSeviyesi));
        }
    }
}
