using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTest : MonoBehaviour
{
    [Header("Settings")]
    public float MoveSpeed = 5f; // Karakterin hareket hýzý

    void Update()
    {
        // Saða doðru hareket ettirme
        transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
    }
}
