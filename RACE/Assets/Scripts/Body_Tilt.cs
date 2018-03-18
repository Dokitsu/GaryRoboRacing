using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_Tilt : MonoBehaviour
{

    private float smooth = 2.0F;
    private float tiltAngle = 30.0F;

    public float bodyAngle;
    public string player;

    private void Start()
    {
        player = transform.root.gameObject.name;
    }

    private void Update()
    {
        //if (player == "Player1")
        //{
            //float tiltAroundX = Input.GetAxis("Horizontal") * tiltAngle;

            //Quaternion target = Quaternion.Euler(tiltAroundX, 0, 0);
            //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        //}
        //if (player == "Player2")
        //{
        //    float tiltAroundX = Input.GetAxis("Horizontal2") * tiltAngle;

        //    Quaternion target = Quaternion.Euler(0, -90, -tiltAroundX);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        //}

        //bodyAngle = -this.transform.rotation.eulerAngles.z;
        //if (transform.rotation.eulerAngles.z > tiltAngle)
        //{
        //    bodyAngle = bodyAngle + 360;
        //}

    }
}
