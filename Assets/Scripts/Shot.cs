using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameManager gm;
    public GameObject target;
    public float speed = 1;
    public bool isMoving = true;
    public GameObject spawnNoteObject;
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
            if(target != null)
            {
                GetComponent<Renderer>().enabled = true;
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
            }
            else
            {
                Debug.Log("nnull");
            }
            
        }
    }

    public void LaunchBall()
    {
        if (spawnNoteObject.transform.childCount > 0)
        {
            target = spawnNoteObject.transform.GetChild(0).gameObject;
            GetComponent<Renderer>().enabled = true;
            isMoving = true;
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "target")
        {
            isMoving = false;
            transform.position = startPos;
            GetComponent<Renderer>().enabled = false;
            Debug.Log("wow");
            //gm.Hit();
        }
        
    }

    public void Hide()
    {
        isMoving = false;
        transform.position = startPos;
        GetComponent<Renderer>().enabled = false;
        Debug.Log("wow");
    }
}
