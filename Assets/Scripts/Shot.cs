using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    void Update()
    {
        if (isMoving)
        {            
            rb.AddForce(force * Time.deltaTime, ForceMode.Acceleration);
        }
    }

    private void Enlarge(Vector3 vector)
    {
        transform.localScale = scale;
        var scaleTo = scale * 15f;
        StartCoroutine(ScaleOverSeconds(vector, scaleTo, 0.5f));
    }

    public IEnumerator ScaleOverSeconds(Vector3 vector, Vector3 scaleTo, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingScale = transform.localScale;
        while (elapsedTime < seconds)
        {
            transform.localScale = Vector3.Lerp(startingScale, scaleTo, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = scaleTo;
        isMoving = true;
        rb.velocity = vector;
    }

    public void LaunchBall(bool correctNode)
    {
        print("launch ball");
        if (spawnNoteObject.transform.childCount > 0) {
            GetComponent<Renderer>().enabled = true;
            rb.velocity = new Vector3(0f, 0f, 0f);            
            Enlarge(correctNode ? force : MissForce());
        }
    }

    public void Hide()
    {
        isMoving = false;
        transform.position = startPos;
        GetComponent<Renderer>().enabled = false;
        Debug.Log("wow");
    }

    private Vector3 MissForce()
    {
        float x = (float)Random.Range(0.1f, 0.3f);
        float y = (float)Random.Range(0.1f, 0.3f);
        return force + new Vector3(x, y, 0);
    }
}
