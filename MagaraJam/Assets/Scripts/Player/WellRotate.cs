using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellRotate : MonoBehaviour
{
    public float donmeHizi = 15f; // D�nme h�z�

    void Update()
    {
        // Z ekseninde s�rekli d�nd�rme
        transform.Rotate(0f, 0f, donmeHizi * Time.deltaTime);
    }
}
