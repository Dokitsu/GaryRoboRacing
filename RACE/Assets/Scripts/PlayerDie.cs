using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerDie : NetworkBehaviour
{
    bool death;

    public Text gameOverText;
	
    void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "cam" && col.gameObject.layer == LayerMask.NameToLayer("Death"))
        {
            Debug.Log("Reeeeeeeeeeeeeeeeeeeee");

            RpcDied();

            Invoke("BackToLobby", 3f);
        }
        return;
    }

    [ClientRpc]
    void RpcDied()
    {
        if (isLocalPlayer)
        {
            gameOverText.text = "You Lose...";
        }
        else
        {
            gameOverText.text = "You Win!!";
        }
    }

    void BackToLobby()
    {
        FindObjectOfType<NetworkLobbyManager>().ServerReturnToLobby();
    }
}
