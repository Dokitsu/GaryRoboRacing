using UnityEngine.Audio;
using UnityEngine;
using System;

public class audiomanager : MonoBehaviour {
    
    //sounds for the player
    public Sound[] sounds;
    public audiomanager Audio;

    void Awake()
    {
        foreach (Sound i in sounds)
        {
            i.source = gameObject.AddComponent<AudioSource>();
            i.source.clip = i.clip;
        }
    }
    void Start()
    {
        Audio = this;
    }

    public void Playsound (string name)
    {
        Debug.Log("sound " + name);
        Sound i = Array.Find(sounds, sound => sound.name == name);
        i.source.Play();
    }
}
