using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    private string[] notes = {"do", "re", "mi", "fa", "so", "la", "ti"};
    private string currNote = "";

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        LaunchBall();
    }

    // Update is called once per frame
    void Update()
    {

        //launch note
        //wait for it to get hit

    }

    public void LaunchBall()
    {
        currNote = notes[(int) Random.Range(0, notes.Length)];
        Debug.Log(currNote);
        //pick random note
    }

    public void Hit()
    {
        score++;
    }
}
