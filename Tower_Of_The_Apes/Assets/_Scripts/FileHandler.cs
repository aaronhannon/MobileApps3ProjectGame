using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class FileHandler
{
    List<HighScore> orderedList = new List<HighScore>();
    bool contains = false;

    [MenuItem("Tools/Write file")]
    public void WriteString(string name,string score)
    {
        //WRITING TO FILE

        string path = "Assets/Resources/test.txt";

        HighScore highScore = new HighScore(name, score);

        List<HighScore> scores = new List<HighScore>();

        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(highScore.name + "\n");
        writer.Write(highScore.highScore + "\n");

        writer.Close();

        //READING FROM FILE

        StreamReader reader = new StreamReader(path);

        string nameFile = reader.ReadLine();

        while (nameFile != null){
            
            string highScoreFile = reader.ReadLine();

            Debug.Log("READ:" + nameFile + " " + highScoreFile);

            scores.Add(new HighScore(nameFile, highScoreFile));

            nameFile = reader.ReadLine();
        }

        reader.Close();

        //foreach (HighScore item in scores)    
        //{
        //    Debug.Log("Score: " + item.highScore);
        //}

        scores.Sort((x, y) => Int32.Parse(x.highScore) - Int32.Parse(y.highScore));

        //List<HighScore> SortedList = scores.OrderByDescending(o => Int32.Parse(o.highScore)).ToList();
        //List<HighScore> list = new List<HighScore>();
        //list.OrderBy(test => Int32.Parse(test.highScore)).ToList();

        foreach (HighScore item in scores)
        {
            Debug.Log("SORTED" + item.name + " " + item.highScore);
        }

        //int i, j; 
        //HighScore temp;
        //bool swapped;
        //for (i = 0; i < scores.Capacity - 1; i++)
        //{
        //    swapped = false;
        //    for (j = 0; j <  - i - 1; j++)
        //    {
        //        if (Int32.Parse(scores[i].highScore) > Int32.Parse(scores[j + 1].highScore))
        //        {
        //            // swap arr[j] and arr[j+1] 
        //            temp = scores[j];
        //            scores[j] = scores[j + 1];
        //            scores[j + 1] = temp;
        //            swapped = true;
        //        }
        //    }

        //    // IF no two elements were  
        //    // swapped by inner loop, then break 
        //    if (swapped == false)
        //        break;
        //}

        //foreach (HighScore item in scores)
        //{
        //    Debug.Log("SORTED" + item.name + " " + item.highScore);
        //}


        //foreach (HighScore item in scores)
        //{

        //    Debug.Log("PARSED: " + Int32.Parse(item.highScore));
        //    if (Int32.Parse(item.highScore) >= highest)
        //    {
        //        highest = Int32.Parse(item.highScore);

        //        contains = containsHighScore(highest);

        //        if (contains == false)
        //        {

        //            orderedList.Add(new HighScore(item.name, item.highScore));

        //        }

        //    }
        //}

        foreach (HighScore item in orderedList)
        {
            Debug.Log("Ordered: " + item.name + " " + item.highScore);
        }

    }

    public bool containsHighScore(int check)
    { 

        foreach (HighScore item in orderedList)
        {
            if(Int32.Parse(item.highScore) == check)
            {
                return true;
            }
        }

        return false;
    }

}
