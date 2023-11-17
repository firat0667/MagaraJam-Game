using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponDamage : MonoBehaviour
{

    public LayerMask collisionLayer;
    public float radius = 3f;

    public int damage = 3;

    private void Update()
    {

        Collider2D target = Physics2D.OverlapCircle(transform.position, radius, collisionLayer);

        if (target)
        {

            if (target.tag == TagManager.ENEMY_HEALTH_TAG)
            {
                target.transform.root.GetComponent<EnemyController>().DealDamage(damage);
            }

        }

    }

} // class

