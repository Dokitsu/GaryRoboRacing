using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Camset : NetworkBehaviour{

    public Campos cam;
    public GameObject camer;

	// Use this for initialization
	void Start ()
    {
        cam = camer.GetComponent<Campos>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
        {
            return;
        }
    }

    public override void OnStartClient()
    {
        Debug.Log("GARYBUN1GARYBUN1");
        cam.setlocalcam(this.gameObject);
    }
}
