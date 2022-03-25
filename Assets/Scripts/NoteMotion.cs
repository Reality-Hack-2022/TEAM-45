using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMotion : MonoBehaviour
{
    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (transform.position.z < 50)
        {
            Explode2();
        }*/
    }

    void Explode()
    {
        ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.main.duration);
    }

    public void Explode2()
    {
        ParticleSystem exp = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(exp, exp.main.duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball")
        {
            Debug.Log("An object entered.");
            Explode2();
        } else
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        print("collision");
        Explode2();
    }
}
