using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class FileHandler
{
    List<HighScore> scores = new List<HighScore>();
    string path = "Assets/Resources/test.txt";
    

    public void WriteString(string name,string score)
    {
        //WRITING TO FILE

        HighScore highScore = new HighScore(name, score);

        

        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(highScore.name + "\n");
        writer.Write(highScore.highScore + "\n");

        writer.Close();

    }

    public void ReadFile()
    {
        //READING FROM FILE

        StreamReader reader = new StreamReader(path);

        string nameFile = reader.ReadLine();

        while (nameFile != null)
        {

            string highScoreFile = reader.ReadLine();

            Debug.Log("READ:" + nameFile + " " + highScoreFile);

            scores.Add(new HighScore(nameFile, highScoreFile));

            nameFile = reader.ReadLine();
        }


        // SORT LIST
        scores = scores.OrderByDescending(o => Int32.Parse(o.highScore)).ToList();
    }



    public List<HighScore> getOrderedHighScores()
    {
        return scores;
    }

}
