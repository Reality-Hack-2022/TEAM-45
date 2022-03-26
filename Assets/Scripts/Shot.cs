using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shot : MonoBehaviour
{
    public GameManager gm;
    public GameObject target;
    public static float speed = 100;
    public bool isMoving = true;
    public GameObject spawnNoteObject;
    private Vector3 startPos;

    private Vector3 force = new Vector3(0, 0.25f, 1.2f) * speed;
    private Rigidbody rb;
    private Vector3 scale = new Vector3(1f, 1f, 1f) * 14f;
    float duration = 0.16f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
       /* LaunchBall(true);*/
    }

/*    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            LaunchBall(false);
        }
    }*/

    private void StartShot(Vector3 vector)
    {
        rb.velocity = new Vector3(0f, 0f, 0f);
        gameObject.transform.localScale = scale;
        var scaleTo = scale * 5f;
        StartCoroutine(ScaleOverSeconds(gameObject, vector, scaleTo, 1.5f));
    }

    public IEnumerator ScaleOverSeconds(GameObject o, Vector3 vector, Vector3 scaleTo, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingScale = o.transform.localScale;
        while (elapsedTime < seconds)
        {
            o.transform.localScale = Vector3.Lerp(startingScale, scaleTo, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        o.transform.localScale = scaleTo;
        print("velocity++++");
        rb.velocity = vector;   
    }

    public void LaunchBall(bool correctNode)
    {
        print("launch ball");
        transform.position = startPos;
        if (spawnNoteObject.transform.childCount > 0) {
            GetComponent<Renderer>().enabled = true;            
            StartShot(correctNode ? force : MissForce());
        }
    }

    public void Hide()
    {
        transform.position = startPos;
        GetComponent<Renderer>().enabled = false;
        Debug.Log("wow");
    }

    private Vector3 MissForce()
    {
        double angle = UnityEngine.Random.Range(0, (float) Math.PI);
        float x = (float) Math.Cos(angle) * speed / 10;
        float y = (float) Math.Sin(angle) * speed / 10;
        return force + new Vector3(x, y, 0);
    }
}
