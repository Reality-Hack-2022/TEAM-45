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

    private void OnTriggerEnter(Collider other) {
        if (other.name == "shot") {           
            if (gm.Hit()) {
                Explode2();                
            }
            other.GetComponent<Shot>().Hide();
        } else if (other.name == "PersonBounds") {
            Debug.Log("huh");
            Destroy(gameObject);
            gm.OnBodyCollision();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        print("collision");
        Explode2();
    }
}
