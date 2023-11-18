using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == TagManager.PLAYER_TAG || target.tag == TagManager.PLAYER_HEALTH_TAG)
        {

            GameplayController.instance.CoinCount++;

            gameObject.SetActive(false);

        }

    }
}
