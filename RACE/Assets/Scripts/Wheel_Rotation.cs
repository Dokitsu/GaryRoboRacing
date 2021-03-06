﻿using System.Collections;
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
    private float maxSpeed = 150;
    private float minSpeed = 50;

    public string player;


    //Jump varibles
    public LayerMask groundLayer;
    public CapsuleCollider col;
    public float fallMulti = 4f;
    public float lowJump = 2f;



    // Use this for initialization
    void Start()
    {
        bodyVelocity = Player.GetComponent<Rigidbody>();
        player = transform.root.gameObject.name;
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

        if (currentSpeed < maxSpeed && currentSpeed > minSpeed)
        {
            wheel_.motorTorque = v;
        }
        if (currentSpeed > maxSpeed)
        {
            wheel_.motorTorque = 0;
        }
       

        //if (player == "Player1")
        //{
            if (currentSpeed < minSpeed)
            {
                wheel_.motorTorque = 10;
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    wheel_.motorTorque = v;
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                wheel_.brakeTorque = breakForce;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                wheel_.brakeTorque = 0;
            }

            if (Grounded() && Input.GetKeyDown(KeyCode.UpArrow))
            {
                bodyVelocity.AddForce(Vector3.up * 8, ForceMode.Impulse);
            }

            if (bodyVelocity.velocity.y < 0)
            {
                bodyVelocity.velocity += Vector3.up * Physics.gravity.y * (fallMulti - 1) * Time.deltaTime;
            }
            else if (bodyVelocity.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow))
            {
                bodyVelocity.velocity += Vector3.up * Physics.gravity.y * (lowJump - 1) * Time.deltaTime;
            }
        //}

        //if (player == "Player2")
        //{
        //    if (currentSpeed < minSpeed)
        //    {
        //        wheel_.motorTorque = 10;
        //        if (Input.GetKey(KeyCode.D))
        //        {
        //            wheel_.motorTorque = v;
        //        }
        //    }
        //    if (Input.GetKeyDown(KeyCode.A))
        //    {
        //        wheel_.brakeTorque = breakForce;
        //    }
        //    if (Input.GetKeyUp(KeyCode.D))
        //    {
        //        wheel_.brakeTorque = 0;
        //    }

        //    if (Grounded() && Input.GetKeyDown(KeyCode.W))
        //    {
        //        bodyVelocity.AddForce(Vector3.up * 8, ForceMode.Impulse);
        //    }

        //    if (bodyVelocity.velocity.y < 0)
        //    {
        //        bodyVelocity.velocity += Vector3.up * Physics.gravity.y * (fallMulti - 1) * Time.deltaTime;
        //    } else if(bodyVelocity.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        //    {
        //        bodyVelocity.velocity += Vector3.up * Physics.gravity.y * (lowJump - 1) * Time.deltaTime;
        //    }
        //}


    }


    private bool Grounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z),col.radius,groundLayer);
    }

    
}
