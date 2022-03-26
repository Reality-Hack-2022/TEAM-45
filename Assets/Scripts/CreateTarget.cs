using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTarget : MonoBehaviour
{    
    public Rigidbody targetFab;

    public void FireTarget(string noteName)
    {
        Rigidbody newBody = Instantiate(targetFab, new Vector3(0f, 25f, 120f), Quaternion.identity);
        newBody.transform.parent = gameObject.transform;
        newBody.velocity = new Vector3(0f, -0.25f, -1.2f) * 20f;

        FindObjectOfType<Audiomanager>().Play("Target_" + noteName);
    }
}
