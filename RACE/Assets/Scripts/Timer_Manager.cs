using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Manager : MonoBehaviour
{
    public Text text;
    private float timeLeft = 4;
    private bool canCount = true;
    public GameObject timerObj;

    void Update()
    {
        if (canCount == true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft > 0)
            {
                text.text = "" + (int)timeLeft;
            }
            else if (timeLeft == 0)
            {
                text.text = "Go!";
            }
            else if (timeLeft < 0)
            {
                canCount = false;
                timerObj.SetActive(false);
            }
        }
    }
}
