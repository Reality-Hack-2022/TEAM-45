using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTrigger : MonoBehaviour
{
    public AudioSource impactSound; 

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.relativeVelocity.magnitude > 1){

            impactSound.Play();
            
        }

    }

}