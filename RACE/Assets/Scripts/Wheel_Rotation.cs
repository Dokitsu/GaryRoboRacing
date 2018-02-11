using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel_Rotation : MonoBehaviour
{
    public WheelCollider wheel_;

    private float angleSpeed = 0;

    public GameObject Body;

    public GameObject Player;

    private Rigidbody bodyVelocity;

    private float breakForce = 100;

    private float currentSpeed;
    private float maxSpeed = 100;
    
    // Use this for initialization
    void Start()
    {
        bodyVelocity = Player.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        currentSpeed = bodyVelocity.velocity.sqrMagnitude;
    }
    // Update is called once per frame
    void Update()
    {
        angleSpeed = Body.GetComponent<Body_Tilt>().bodyAngle; 

        float v = angleSpeed;

        if(currentSpeed < maxSpeed)
        {
            wheel_.motorTorque = v;
        }
        else
        {
            wheel_.motorTorque = 0;
            Debug.Log(currentSpeed);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            wheel_.brakeTorque = breakForce;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            wheel_.brakeTorque = 0;
        }
    }
}
