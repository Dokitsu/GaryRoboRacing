using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Manager : MonoBehaviour
{
    public GameObject no3, no2, no1, go, win, lose, loading, loadingText, loadingCircle;
    private float timeLeft = 6;
    private bool canCount = true;
    private bool cantime = true;

    void Update()
    {
        if (canCount == true)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 3 && timeLeft > 2)
            {
                win.SetActive(false);
                lose.SetActive(false);
                loading.SetActive(false);
                loadingText.SetActive(false);
                loadingCircle.SetActive(false);
                no3.SetActive(true);
                timersound();
            }
            else if (timeLeft <= 2 && timeLeft > 1)
            {
                no3.SetActive(false);
                no2.SetActive(true);
            }
            else if (timeLeft <= 1 && timeLeft > 0)
            {
                no2.SetActive(false);
                no1.SetActive(true);
            }
            else if (timeLeft <= 0 && timeLeft > -1)
            {
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

    void timersound()
    {
        if (cantime)
        {
            cantime = false;
            FindObjectOfType<audiomanager>().Playsound("timer");
        }
    }
}
