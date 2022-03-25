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
    private int numOfTries = 2;
    private int currTry = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = 5;
        LaunchTarget();
    }

    // Update is called once per frame
    void Update()
    {

        //launch note
        //wait for it to get hit

    }

    public void LaunchTarget()
    {
        currTry = 0;
        currNote = notes[(int) Random.Range(0, notes.Length)];
        Debug.Log(currNote);
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

        if(currTry == numOfTries)
        {
            LaunchTarget();
        }

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
