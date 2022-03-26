using UnityEngine.Audio;
using UnityEngine;
using System;
 
 
public class Audiomanager : MonoBehaviour {
   
    public Sound[] sounds;
    
    //use this for initialization
    void Awake () {

        foreach (Sound s in sounds)
        {

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume; 
            s.source.loop = s.loop;

        }
    }

    public void Play (string name)
    { 
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Play();
            print("playing: " + s);
        }

    }
    void Start ()
    {
        Play("Theme1");

    }
}
