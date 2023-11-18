using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveFX : MonoBehaviour
{
    // called every time when game object is activated
    void OnEnable()
    {
        Invoke("DeactivateGameObject", 2f);
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
