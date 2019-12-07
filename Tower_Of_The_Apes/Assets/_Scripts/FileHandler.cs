using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class FileHandler
{
    [MenuItem("Tools/Write file")]
    public void WriteString(string name,float score)
    {
        string path = "Assets/Resources/test.txt";

        HighScore highScore = new HighScore();
        highScore.name = name;
        highScore.highScore = score;

        string json = JsonUtility.ToJson(highScore);


        //Convert JSON back into object
        //myObject = JsonUtility.FromJson<MyClass>(json);


       StreamWriter writer = new StreamWriter(path, true);
        writer.Write(json);
        writer.Close();
    }

}
