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

    private Vector3 force = new Vector3(0, 0.2f, 1f) * speed;
    private Rigidbody rb;
    private Vector3 scale = new Vector3(1f, 1f, 1f) * 14f;
    float duration = 0.16f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        LaunchBall();
    }

    void Update()
    {
        if (isMoving)
        {            
            rb.AddForce(force * Time.deltaTime, ForceMode.Acceleration);
        }
    }

    private void Enlarge()
    {
        var scaleTo = scale * 5f;
        StartCoroutine(ScaleOverSeconds(gameObject, scaleTo, 1.0f));
    }

    public IEnumerator ScaleOverSeconds(GameObject objectToScale, Vector3 scaleTo, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingScale = objectToScale.transform.localScale;
        while (elapsedTime < seconds)
        {
            objectToScale.transform.localScale = Vector3.Lerp(startingScale, scaleTo, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToScale.transform.localScale = scaleTo;
    }

    public void LaunchBall()
    {
        print("launch ball");
        if (spawnNoteObject.transform.childCount > 0)
        {
            isMoving = true;
            GetComponent<Renderer>().enabled = true;
            rb.velocity = new Vector3(0f, 0f, 0f);
            transform.localScale = scale;
            Enlarge();
            rb.AddForce(force, ForceMode.Acceleration);
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
