using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_Movement : NetworkBehaviour
{
    //force that drives the engine
    private float Motor = 30;

    //the wheelcollider on the local gameobject
    public WheelCollider wheel_;

    //Speeds of the robot and the limits
    private float currentSpeed;
    private float maxSpeed = 150;
    private float minSpeed = 50;
    private float breakForce = 100;

    public GameObject player;
    private Rigidbody pRigidBody;

    void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }
        pRigidBody = player.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        currentSpeed = pRigidBody.velocity.sqrMagnitude;
    }
    void Update()
    {
        
        float v = Input.GetAxis("Horizontal") * Motor;
        if (currentSpeed < minSpeed)
        {
            wheel_.motorTorque = 10;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                wheel_.motorTorque = v;
            }
        }
        if (currentSpeed < maxSpeed && currentSpeed > minSpeed)
        {
            wheel_.motorTorque = v;
        }
        if (currentSpeed > maxSpeed)
        {
            wheel_.motorTorque = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            wheel_.brakeTorque = breakForce;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            wheel_.brakeTorque = 0;
        }

    }


}
