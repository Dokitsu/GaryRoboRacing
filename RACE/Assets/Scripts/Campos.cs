using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Campos : MonoBehaviour {

    public static Campos cammy;

    public GameObject p1;
    public GameObject p2;

    private float p1d;
    private float p2d;

    private float avgD;

    private GameObject[] players;


    void Start()
    {
        cammy = this;
    }

    public void camset(GameObject player)
    {
        if (p1 == null)
        {
            p1 = player;
        }
        else if (p1 != null)
        {
            p2 = player;
        }

    }

    // Update is called once per frame
    void Update ()
    {
        p1d = p1.transform.position.z;
        p2d = p2.transform.position.z;

        avgD = (p1d + p2d) / 2;

        transform.position = new Vector3(20, 5, avgD);

        if (p1.transform.position.z >= transform.localPosition.z + 15)
        {
            transform.position = new Vector3(20f, 5f, p1.transform.position.z - 15);
            return;
        }

        if (p2.transform.position.z >= transform.localPosition.z + 15)
        {
            transform.position = new Vector3(20f, 5f, p2.transform.position.z - 15);
            return;
        }
    }
}
