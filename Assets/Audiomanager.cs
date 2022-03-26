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
            s.source.pitch = s.pitch;

        }
    }

    public void Play (string name)
    { 
        Sound s = Array.Find(sounds, sound => sound.name == name); 
        s.source.Play(); 
        
        print ("playing: " + s);

    }
}
