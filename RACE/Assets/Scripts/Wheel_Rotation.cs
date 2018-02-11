using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel_Rotation : MonoBehaviour
{
    public float motorMovement;
    public WheelCollider wheel_;

    private float angleSpeed = 0;

    public GameObject Body;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        angleSpeed = Body.GetComponent<Body_Tilt>().bodyAngle; 

        float v = angleSpeed;

        wheel_.motorTorque = v;
    }
}
