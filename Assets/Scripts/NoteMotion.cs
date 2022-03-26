using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMotion : MonoBehaviour
{
    public ParticleSystem explosion;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        if (other.name == "shot")
        {
            Debug.Log("An object entered.");
            Explode2();
            gm.Hit();
            other.GetComponent<Shot>().Hide();
        } 
        else if(other.name == "PersonBounds")
        {
            Debug.Log("huh");
            Destroy(gameObject);
            gm.OnBodyCollision();
        }
        //
    }

    void OnCollisionEnter(Collision collision)
    {
        print("collision");
        Explode2();
    }
}
