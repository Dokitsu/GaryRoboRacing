using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerDie : NetworkBehaviour
{
    //Text winCondition;

    GameObject winC;
    GameObject loseC;

    GameObject mainCamera;
    void Awake()
    {
        winC = GameObject.Find("Win");
        Debug.Log(winC);

        loseC = GameObject.Find("Lose");
        Debug.Log(loseC);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "cam" && col.gameObject.layer == LayerMask.NameToLayer("Death"))
        {
            RpcDied();

            Invoke("BackToLobby", 5f);
        }
        return;
    }

    [ClientRpc]
    void RpcDied()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        mainCamera.transform.eulerAngles = new Vector3(-45,-90,0);

        if (isLocalPlayer)
        {
            loseC.SetActive(true);
        }
        else
        {
            winC.SetActive(true);
        }
    }

    void BackToLobby()
    {
        FindObjectOfType<NetworkLobbyManager>().ServerReturnToLobby();
    }
}
