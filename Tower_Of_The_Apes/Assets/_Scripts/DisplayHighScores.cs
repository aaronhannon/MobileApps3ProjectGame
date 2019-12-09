using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighScores : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        FileHandler fh = new FileHandler();

        //fh.WriteString("Bob", "100");

        fh.ReadFile();
        List<HighScore> scores = new List<HighScore>();

        scores = fh.getOrderedHighScores();

        foreach (HighScore item in scores)
        {
            Debug.Log("Display Script: " + item.name + " " + item.highScore);
        }

        

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
