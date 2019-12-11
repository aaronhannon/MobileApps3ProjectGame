using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighScores : MonoBehaviour
{
    
    
    void Start()
    {
        FileHandler fh = new FileHandler();

        //Reads in the file and sorts all the values
        fh.ReadFile();
        List<HighScore> scores = new List<HighScore>();

        //Retrieving the sorted list
        scores = fh.getOrderedHighScores();

       //So the places holders gameobjects are called 1-5 so I am using a loop to find them all and
       //I am just pairing the index of the loop to the index of the list to the name of the game object.
        for (int i = 0; i < 5; i++)
        {
            GameObject textObject = GameObject.Find((i+1).ToString());
            TMP_Text text = textObject.GetComponent<TMP_Text>();
            text.text = i+1 + ". " + scores[i].name + " " + scores[i].highScore;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
