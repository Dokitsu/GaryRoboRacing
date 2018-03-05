using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDie : MonoBehaviour
{

    public float count;
    bool death;

    public Text counterimg;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        counterimg.text = Mathf.RoundToInt(count).ToString();

		if (death == true)
        {
            count += Time.deltaTime;
        }

        if (death == false)
        {
            if (count > 0)
            {
                count -= Time.deltaTime;
            }
        }

        if (count > 5)
        {
            Destroy(gameObject);
        }
	}


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Death_Obj")
        {
            death = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Death_Obj")
        {
            death = false;
        }
    }
}
