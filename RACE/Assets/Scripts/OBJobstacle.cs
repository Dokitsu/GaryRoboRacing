using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJobstacle : MonoBehaviour
{
    public Rigidbody obj;
    public CapsuleCollider cap;

    // Use this for initialization
    void Start()
    {
        obj = GetComponent<Rigidbody>();
        cap = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            obj.AddForce(transform.forward * 400);
            obj.AddTorque(transform.right * 400);
            cap.enabled = !cap.enabled;
            //Destroy(obj);
            Debug.Log("hit");
        }
    }
}