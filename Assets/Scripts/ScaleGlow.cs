using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleGlow : MonoBehaviour
{
    float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += Vector3.one * speed * Time.deltaTime;
    }
}
