    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerhits : MonoBehaviour
{
    // Start is called before the first frame updat
    public AudioSource notehitC1;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1)
        {

            notehitC1.Play();
        }

    }
}
