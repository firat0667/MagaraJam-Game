using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZiplamaBari : MonoBehaviour
{
    public static float maxZiplama = 100;
    public static float  ZiplamaSeviyesi = 0;
    float GercekScale;
    float animasyonYavasligi = 20;
    public static float artisSeviyesi = 0.5f;
    void Update()
    {
        GercekScale = ZiplamaSeviyesi / maxZiplama;
        if (transform.localScale.x > GercekScale)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + (GercekScale - transform.localScale.y) / animasyonYavasligi, transform.localScale.z);
        }

        if (ZiplamaSeviyesi >= maxZiplama)
        {
            ZiplamaSeviyesi = maxZiplama;
        }
        if (Input.GetKey(KeyCode.A))
        {
            ZiplamaSeviyesi += artisSeviyesi;
        }
    }
}
