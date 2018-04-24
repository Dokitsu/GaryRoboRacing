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

    //Jump varibles
    public LayerMask groundLayer;
    public CapsuleCollider col;
    public float fallMulti = 4f;
    public float lowJump = 2f;

    //tilt variables
    public GameObject BodyT;
    private float smooth = 2.0F;
    private float tiltAngle = 15.0F;

    //Timer variables
    private float timeLeft = 6;
    private bool canMove = false;

    void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }
        pRigidBody = player.GetComponent<Rigidbody>();
        col = player.GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
        currentSpeed = pRigidBody.velocity.sqrMagnitude;
    }


    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            canMove = true;
        }
        if(canMove == true)
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


            if (Grounded() && Input.GetKeyDown(KeyCode.UpArrow))
            {
                pRigidBody.AddForce(Vector3.up * 8, ForceMode.Impulse);
            }


            float tiltAroundX = Input.GetAxis("Horizontal") * tiltAngle;

            Quaternion target = Quaternion.Euler(tiltAroundX, 0, 0);
            BodyT.transform.rotation = Quaternion.Slerp(BodyT.transform.rotation, target, Time.deltaTime * smooth);

        }
    }

    private bool Grounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius, groundLayer);
    }

}
