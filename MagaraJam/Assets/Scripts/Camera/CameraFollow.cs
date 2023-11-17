using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Elements")]
    public Transform PlayerTransform;
    [Header("Settings")]
    public float FollowingXdistance = 5f;

    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = PlayerTransform.position.x+FollowingXdistance;
        transform.position = temp;

    }
}
