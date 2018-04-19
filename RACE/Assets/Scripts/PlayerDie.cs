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
        Debug.Log(col.ToString());
        if (col.gameObject.tag == "Death_OBJ")
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
