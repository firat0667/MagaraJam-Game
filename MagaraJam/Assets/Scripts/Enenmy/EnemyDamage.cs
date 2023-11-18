using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;

    public int damage = 3;

    void Update()
    {

        if (GameplayController.instance.EnemyGoal == EnemyGoal.PLAYER)
        {
            AttackPlayer();
        }

        if (GameplayController.instance.EnemyGoal == EnemyGoal.FENCE)
        {
            AttackFence();
        }

    }

    void AttackPlayer()
    {

        if (GameplayController.instance.PlayerAlive)
        {

            Collider2D target = Physics2D.OverlapCircle(transform.position, radius, collisionLayer);

            if (target.tag == TagManager.PLAYER_HEALTH_TAG)
            {
                Debug.Log("asdasdsa");
                target.GetComponent<PlayerHealth>().DealDamage(damage);

            }
        }
    }

    void AttackFence()
    {

        if (!GameplayController.instance.FenceDestroyed)
        {

            Collider2D target = Physics2D.OverlapCircle(transform.position, radius, collisionLayer);

            if (target.tag == TagManager.FENCE_TAG)
            {
              //  target.GetComponent<FenceHealth>().DealDamage(damage);
            }

        }

    }
}
