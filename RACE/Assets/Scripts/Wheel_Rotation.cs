using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel_Rotation : MonoBehaviour
{
    public float motorMovement;
    public WheelCollider wheel_;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float v = motorMovement;

        wheel_.motorTorque = v;
    }
}
