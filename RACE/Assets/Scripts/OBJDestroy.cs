using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJDestroy : MonoBehaviour {

    public Player_Movement bum;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "OBJ")
        {
            //Destroy(collision.gameObject);

            bum = GetComponent<Player_Movement>();
            bum.Bump();
        }
    }
	
}
