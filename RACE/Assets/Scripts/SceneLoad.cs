using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour {

    [SerializeField]
    string _sceneName;
    public void Loadscene()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
