using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Manager : MonoBehaviour
{
    public GameObject no3, no2, no1, go;
    private float timeLeft = 3;
    private bool canCount = true;

    void Update()
    {
        if (canCount == true)
        { 
            timeLeft -= Time.deltaTime;
            Debug.Log(timeLeft);
            if (timeLeft <= 3 && timeLeft > 2)
            {
                Debug.Log("3");
                no3.SetActive(true);
            }
            else if (timeLeft <= 2 && timeLeft > 1)
            {
                Debug.Log("2");
                no3.SetActive(false);
                no2.SetActive(true);
            }
            else if (timeLeft <= 1 && timeLeft > 0)
            {
                Debug.Log("1");
                no2.SetActive(false);
                no1.SetActive(true);
            }
            else if (timeLeft <= 0 && timeLeft > -1)
            {
                Debug.Log("go");
                no1.SetActive(false);
                go.SetActive(true);     
            }
            else if (timeLeft <= -1)
            {
                go.SetActive(false);
                canCount = false;
            }
        }
    }
}
