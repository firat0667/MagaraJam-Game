using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ziplama : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2;
    public void Update()
    {
        jump();
    }

    public void jump()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            rigidbody2.AddForce(new Vector2(0, ZiplamaBari.ZiplamaSeviyesi*20));
            ZiplamaBari.ZiplamaSeviyesi = 0;
        }
    }
}
