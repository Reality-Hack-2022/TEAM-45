using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public GameManager gm;
    public Shot shot;

    public GameObject hoop;
    public Material currMaterial;
    public Material glowMaterial;

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
            other.gameObject.GetComponent<ButtonNote>().Reset();
            shot.LaunchBall(gm.IsNoteCorrect());
            StartCoroutine(Glow());
        }
    }

    IEnumerator Glow()
    {
        hoop.GetComponent<Renderer>().material = glowMaterial;
        yield return new WaitForSeconds(.5f);
        hoop.GetComponent<Renderer>().material = currMaterial;
    }
}
