using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingArm : MonoBehaviour
{

    public GameObject leftArm;
    public Camera mainCam;
    public Vector3 mousPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateArm();
    }

    void RotateArm()
    {
        mousPos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = transform.position - mousPos;

        float rotZ = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, -rotZ);
    }
}
