using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Controller : MonoBehaviour
{
    public GameObject Background;

    void Awake()
    {
        DontDestroyOnLoad(Background);
    }
}

