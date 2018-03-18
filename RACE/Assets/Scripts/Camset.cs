using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Camset : NetworkBehaviour
{
    private void Start()
    {
        Campos.cammy.camset(gameObject);
    }
}
