using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNote : MonoBehaviour
{
    
    public Rigidbody fab;
    //public GameObject glow;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Rigidbody newBody = Instantiate(fab, new Vector3(0f, .50f, 100f), Quaternion.identity);
            // newBody.AddForce(new Vector3(0f, 1f, -1f) * 100f);
            newBody.velocity = new Vector3(0f, 0f, -1f) * 20f;

            //GameObject newGlow = Instantiate(glow, new Vector3(0f, .50f, 100f), Quaternion.identity);
        }
    }
}