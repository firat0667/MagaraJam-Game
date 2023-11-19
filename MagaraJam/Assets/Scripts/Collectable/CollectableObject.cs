using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CollectableObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TagManager.PLAYER_TAG || collision.gameObject.tag == TagManager.PLAYER_HEALTH_TAG)
        {

            GameplayController.instance.CoinCount++;

            gameObject.SetActive(false);

        }
    }
}
