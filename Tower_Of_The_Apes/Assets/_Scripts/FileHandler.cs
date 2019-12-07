using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class FileHandler
{
    [MenuItem("Tools/Write file")]
    public void WriteString(string name,string score)
    {
        string path = "Assets/Resources/test.txt";

        HighScore highScore = new HighScore();
        highScore.name = name;
        highScore.highScore = score;

        List<HighScore> scores = new List<HighScore>();

        //HighScore[] player = JsonUtility.FromJson<HighScore[]>(fileData);
        //Debug.Log(player[0].name);
        //Debug.Log(player[1].name);


        //string json = JsonUtility.ToJson(highScore,true)+","+"\n";


        //Convert JSON back into object
        //myObject = JsonUtility.FromJson<MyClass>(json);

        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(highScore.name + "\n");
        writer.Write(highScore.highScore + "\n");

        writer.Close();

        StreamReader reader = new StreamReader(path);

        string nameFile = reader.ReadLine();

        while (nameFile != null){
            
            string highScoreFile = reader.ReadLine();

            Debug.Log(nameFile + " " + highScoreFile);

            HighScore highScoreRead = new HighScore();
            highScore.name = nameFile;
            highScore.highScore = highScoreFile;
            Debug.Log("OBJECT:" + highScoreRead.highScore);
            scores.Add(highScoreRead);

            nameFile = reader.ReadLine();
        }

        reader.Close();

        foreach (var item in scores)
        {
            Debug.Log(item.highScore);
        }

        

        //JsonUtility.FromJson<HighScore>();




    }

}
