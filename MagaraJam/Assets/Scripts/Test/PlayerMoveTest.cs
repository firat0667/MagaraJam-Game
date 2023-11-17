using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTest : MonoBehaviour
{
    [Header("Settings")]
    public float MoveSpeed = 5f; // Karakterin hareket h�z�

    void Update()
    {
        // Sa�a do�ru hareket ettirme
        transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
    }
}
