using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ZiplamaBari : MonoBehaviour
{
    public static float maxZiplama = 100;
    public static float  ZiplamaSeviyesi = 0;
    float GercekScale;
    float animasyonYavasligi = 20;
    public static float artisSeviyesi = 0.5f;
    [SerializeField] bool GroundCheck = false;
    void Update()
    {
        GercekScale = ZiplamaSeviyesi / maxZiplama;
        if (transform.localScale.x > GercekScale)
        
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + (GercekScale - transform.localScale.y) / animasyonYavasligi, transform.localScale.z);
        

        if (ZiplamaSeviyesi >= maxZiplama)
        
            ZiplamaSeviyesi = maxZiplama;
        if (Input.GetKey(KeyCode.A))
        {
            ZiplamaSeviyesi += artisSeviyesi;
            UnityEngine.Debug.Log("Deðiyormu");
            //GroundCheck = true;
        }
    }
    //void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Zemin")) //&& !GroundCheck)
    //    {                  
     //       if (Input.GetKey(KeyCode.A))
     //       {
     //           ZiplamaSeviyesi += artisSeviyesi;
     //           UnityEngine.Debug.Log("Deðiyormu");
                //GroundCheck = true;
        //    }


        //}

   // }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Zemin"))
    //    
    //        GroundCheck = true;
    //    
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Zemin"))
     //   {
    //        GroundCheck = false;
    //        UnityEngine.Debug.Log("Deðiyormu");
    //    }

    //}
}
