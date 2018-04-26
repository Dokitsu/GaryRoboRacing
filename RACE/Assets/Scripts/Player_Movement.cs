using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_Movement : NetworkBehaviour
{
    //mover variables
    private float speed = 10f;
    private float jumpForce = 30f;
    private float gravity = 90f;
    private Vector3 directionVector = Vector3.zero;
    private Vector3 movingVector;
    private Vector3 afkVector;

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
        movingVector = new Vector3(0, 0, speed);
        afkVector = new Vector3(0, 0, speed - 5);
    }

    void Update()
    {
        CharacterController controller = gameObject.GetComponent<CharacterController>();
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            canMove = true;
        }
        if(canMove == true)
        {

            if (controller.isGrounded == true && Input.GetKey(KeyCode.RightArrow) == true)
            {

                directionVector = Vector3.Lerp(directionVector,movingVector,Time.deltaTime * smooth);
                directionVector = transform.TransformDirection(directionVector);

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    directionVector.y = jumpForce;
                }

                float tiltAroundX = Input.GetAxis("Horizontal") * tiltAngle;
                Quaternion target = Quaternion.Euler(tiltAroundX, 0, 0);
                BodyT.transform.rotation = Quaternion.Slerp(BodyT.transform.rotation, target, Time.deltaTime * smooth);
            }
            else if (controller.isGrounded && Input.GetKey(KeyCode.RightArrow) == false)
            {
                directionVector = Vector3.Lerp(directionVector, afkVector, Time.deltaTime * smooth);
                directionVector = transform.TransformDirection(directionVector);

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    directionVector.y = jumpForce;
                }

                float tiltAroundX = Input.GetAxis("Horizontal") * tiltAngle;
                Quaternion target = Quaternion.Euler(tiltAroundX, 0, 0);
                BodyT.transform.rotation = Quaternion.Slerp(BodyT.transform.rotation, target, Time.deltaTime * smooth);
            }

            directionVector.y -= gravity * Time.deltaTime;

            controller.Move(directionVector * Time.deltaTime);

        }
    }
}
