using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    private string[] notes = {"do", "re", "mi", "fa", "so", "la", "ti"};
    private string currNote = "do";
    public string selectedNote = "";
    public GameObject NotesContainer;
    public GameObject Mallet;
    public CreateNote createNoteScript;

    private int numOfTries = 2;
    private int currTry = 0;

    
    private float period = 7f;
    private float nextActionTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        score = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {

            nextActionTime = Time.time + period;
            Debug.Log("time " + Time.time);
            LaunchTarget();
        }

    }

    public void LaunchTarget()
    {
        currTry = 0;
        currNote = notes[(int) Random.Range(0, notes.Length)];
        Debug.Log(currNote);
        createNoteScript.FireTarget();
        //pick random note
    }

    public void Hit()
    {
        currTry++;
        if(selectedNote == currNote)
        {
            score++;
        }
        else
        {
            Debug.Log("wrong note");
        }

        /*if(currTry == numOfTries)
        {
            LaunchTarget();
        }*/

        Reset();
    }

    private void Reset()
    {
        Mallet.GetComponent<Collider>().enabled = true;
        foreach(Transform t in NotesContainer.transform)
        {
            t.GetComponent<Renderer>().enabled = true;
        }
    }
}
