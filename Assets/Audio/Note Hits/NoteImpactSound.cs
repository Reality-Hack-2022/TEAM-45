using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource impactSound; 

    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.relativeVelocity.magnitude > 1){

            impactSound.Play();
            
        }

    }

}
