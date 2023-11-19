using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float _move_Speed = 1f;

    public void Move(Transform targetTransform)
    {

        Flip(targetTransform);

        transform.position =
                     Vector3.MoveTowards(transform.position,
                                         new Vector3(targetTransform.position.x-15f,
                                                     gameObject.transform.position.y),
                                         _move_Speed * Time.deltaTime);

    }

    void Flip(Transform targetTransform)
    {

        Vector3 tempPos = transform.position;
        Vector3 tempScale = transform.localScale;

        if (targetTransform.position.x-15f > (tempPos.x + 0.08f))
        {
            tempScale.x = -1f;
        }
        else if (targetTransform.position.x < (tempPos.x - 0.08f))
        {
            tempScale.x = 1f;
        }

        transform.localScale = tempScale;
    }

}