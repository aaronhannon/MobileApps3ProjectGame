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
    string path = "./Assets/Resources/scores.txt";
    

    //Writes the Name and Score to a file
    public void WriteString(string name,string score)
    {
        

        HighScore highScore = new HighScore(name, score);

        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(highScore.name + "\n");
        writer.Write(highScore.highScore + "\n");

        writer.Close();

    }

    //Reads all the Items from the file and turns them in Highscore Objects and added to a list.
   // That list is then sorted using Linq
    public void ReadFile()
    {
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


    //Gets the ordered list
    public List<HighScore> getOrderedHighScores()
    {
        return scores;
    }

}
