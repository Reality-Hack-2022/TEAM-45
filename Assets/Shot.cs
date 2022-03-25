using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameManager gm;
    public GameObject target;
    public float speed = 1;
    public bool isMoving = true;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
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

    public void LaunchBall()
    {
        GetComponent<Renderer>().enabled = true;
        isMoving = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "note")
        {
            isMoving = false;
            transform.position = startPos;
            GetComponent<Renderer>().enabled = false;
            Debug.Log("wow");
            gm.Hit();
        }
        
    }
}
