using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNote : MonoBehaviour
{
    public GameObject target;
    public float speed = 1;
    public bool isMoving = true;
    private Vector3 startPos;
    public GameObject shot;

    // Start is called before the first frame update
    void Start()
    {
        shot = GameObject.Find("shot");
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            GetComponent<Renderer>().enabled = true;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Mallet")
        {
            isMoving = true;
            other.gameObject.GetComponent<Collider>().enabled = false;
            shot.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        }
    }

    public void Reset()
    {
        isMoving = false;
        transform.position = startPos;
        GetComponent<Renderer>().enabled = true;

    }
}
