using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerDie : NetworkBehaviour
{
    Text gameOverText;

    GameObject mainCamera;
	
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
        gameOverText = GameObject.FindObjectOfType<Text>();

        if (isLocalPlayer)
        {
            gameOverText.text = "You Lost...";
        }
        else
        {
            gameOverText.text = "You won!";
        }
    }

    void BackToLobby()
    {
        FindObjectOfType<NetworkLobbyManager>().ServerReturnToLobby();
    }
}
