using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellRotate : MonoBehaviour
{
    public float donmeHizi = 15f; // Dönme hýzý

    void Update()
    {
        // Z ekseninde sürekli döndürme
        transform.Rotate(0f, 0f, donmeHizi * Time.deltaTime);
    }
}
