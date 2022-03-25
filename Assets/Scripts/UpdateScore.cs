using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateScore : MonoBehaviour
{

    public GameManager gm;
    //public Text text;
    int score;

    void Start()
    {
        
    }

    void Update()
    {
        score = gm.score;
/*        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            print(child);
        }*/
        GetComponentsInChildren<TextMeshPro>()[0].text = score + "";
        //text.text = score + "";
    }
}
