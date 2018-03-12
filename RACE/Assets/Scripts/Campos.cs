using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Campos : MonoBehaviour {

    public GameObject p1;
    public GameObject p2;
    public GameObject Cam;

    private float p1d;
    private float p2d;

    private float avgD;

    private GameObject[] players;

    void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        p1 = players[0];
        p2 = players[1];
    }

    // Update is called once per frame
    void Update ()
    {
        p1d = p1.transform.position.z;
        p2d = p2.transform.position.z;

        avgD = (p1d + p2d) / 2;

        Cam.transform.position = new Vector3(0, 5, avgD);

        if (p1.transform.position.z >= Cam.transform.localPosition.z + 18/2)
        {
            Cam.transform.position = p1.transform.position + new Vector3(2.6f, 4.5f, -18/2);
            //cV.velocity = p1V.velocity;
            return;
        }

        if (p2.transform.position.z >= Cam.transform.localPosition.z + 18 / 2)
        {
            Cam.transform.position = p2.transform.position + new Vector3(0.8f, 4.5f, -18/2);
            //cV.velocity = p2V.velocity;
            return;
        }
	}
}
