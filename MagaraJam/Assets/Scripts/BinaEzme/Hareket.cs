using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hareket : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Animasyon anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
    if (Input.GetKey(KeyCode.D))
        {
        rb.AddForce(new Vector2(3f, 0f));
        anim.TurnAnimation(true);
        }
    if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-3f, 0f));            
        }
    }
}
