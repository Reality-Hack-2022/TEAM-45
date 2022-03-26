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
    public CreateTarget targetScript;

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
        targetScript.FireTarget(currNote);
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
            FindObjectOfType<Audiomanager>().Play("Impact_" + currNote);
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
        FindObjectOfType<Audiomanager>().Play("Body");
    }

    private void Reset()
    {
        //Mallet.GetComponent<Collider>().enabled = true;
        foreach(Transform t in NotesContainer.transform)
        {
            t.GetComponent<Renderer>().enabled = true;
        }
    }

    public bool IsNoteCorrect()
    {
        return currNote == selectedNote;
    }
}
