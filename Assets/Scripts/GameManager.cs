using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    private string[] notes = {"do", "re", "mi", "fa", "sol", "la", "ti"};
    private string currNote = "do";
    public string selectedNote = "";
    public GameObject NotesContainer;
    public GameObject Mallet;
    public Rigidbody targetFab;

    private int numOfTries = 2;
    private int currTry = 0;
    private int scoresInARow = 0;

    
    private float period = 7f;
    private float nextActionTime = 0f;

    void Start()
    {
        score = 5;
        
    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {

            nextActionTime = Time.time + period;
            //Debug.Log("time " + Time.time);
            LaunchTarget();
        }

    }

    public void LaunchTarget()
    {
        Mallet.GetComponent<Collider>().enabled = true;
        currTry = 0;
        currNote = notes[(int) Random.Range(0, notes.Length)];
        Debug.Log(currNote);
        FireTarget(currNote);
        //pick random note
    }

    public bool Hit()
    {
        currTry++;
        bool res = false;
        if(selectedNote == currNote)
        {
            score++;
            scoresInARow++;
            if (scoresInARow > 2) {
                score += scoresInARow - 2;
            }
            res = true;
        }
        else
        {
            score--;
            Debug.Log("wrong note");
        }

        /*if(currTry == numOfTries)
        {
            LaunchTarget();
        }*/

        Reset();
        return res;
    }

    public void OnBodyCollision()
    {
        score--;
        Reset();
    }

    private void Reset()
    {
        //Mallet.GetComponent<Collider>().enabled = true;
        foreach(Transform t in NotesContainer.transform)
        {
            t.GetComponent<Renderer>().enabled = true;
        }
    }

    private void FireTarget(string noteName)
    {
        Rigidbody newBody = Instantiate(targetFab, new Vector3(0f, 25f, 120f), Quaternion.identity);
        newBody.transform.parent = gameObject.transform;
        newBody.velocity = new Vector3(0f, -0.2f, -1f) * 20f;
        
        FindObjectOfType<Audiomanager>().Play("Target_" + noteName);
    }

    public bool IsNoteCorrect()
    {
        return currNote == selectedNote;
    }
}
