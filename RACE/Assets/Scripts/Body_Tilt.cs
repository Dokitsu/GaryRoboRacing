using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_Tilt : MonoBehaviour
{

    private float smooth = 2.0F;
    private float tiltAngle = 30.0F;

    private void Start()
    {
        
    }

    private void Update()
    {
        float tiltAroundX = Input.GetAxis("Horizontal") * tiltAngle;
        Quaternion target = Quaternion.Euler(0, -90, -tiltAroundX);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
