using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public GameManager gm;
    public Shot shot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "button")
        {
            gm.selectedNote = other.name;
            other.GetComponent<Renderer>().enabled = false;
            shot.LaunchBall();
        }
    }
}
