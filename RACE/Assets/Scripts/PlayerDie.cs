using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerDie : NetworkBehaviour
{
    GameObject winC;
    GameObject loseC;

    GameObject mainCamera;
    void Awake()
    {
        winC = GameObject.Find("Win");

        loseC = GameObject.Find("Lose");
    }

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.name == "DeathCube")
        {
            RpcDied();

            Invoke("BackToLobby", 5f);
        }
        return;
    }

    [ClientRpc]
    void RpcDied()
    {
        Debug.Log("REEEEEEEEEEE");
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
