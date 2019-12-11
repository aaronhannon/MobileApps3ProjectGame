using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//HIGHSCORE OBJECT
[Serializable]
public class HighScore { 

    public string name { get; set; }
    public string highScore { get; set; }

    public HighScore(string name, string highScore)
    {       
        this.name = name;
        this.highScore = highScore;
        Debug.Log("HighScore created");
    }
}
