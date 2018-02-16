using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campos : MonoBehaviour {

    public GameObject p1;
    public GameObject p2;
    public GameObject Cam;

    private Rigidbody p1V;
    private Rigidbody cV;

    private float p1d;
    private float p2d;

    private float avgD;

	// Use this for initialization
	void Start ()
    {
        p1V = p1.GetComponent<Rigidbody>();
        cV = Cam.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        p1d = p1.transform.position.z;
        p2d = p2.transform.position.z;

        avgD = (p1d + p2d) / 2;

        if (p1.transform.position.z >= Cam.transform.localPosition.z + 18/2)
        {
            Debug.Log("");
            cV.velocity = p1V.velocity;
            return;
        }

        if (p2.transform.position.z >= Cam.transform.localPosition.z + 18 / 2)
        {
            Debug.Log("");
            cV.velocity = p1V.velocity;
            return;
        }


        Cam.transform.position = new Vector3(0, 0, avgD);


	}
}
