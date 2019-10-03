using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class FileHandler
{
    [MenuItem("Tools/Write file")]
    public void WriteString(string data)
    {
        string path = "Assets/Resources/test.txt";
        
        StreamWriter writer = new StreamWriter(path, true);
        writer.Write(data);
        writer.Close();
    }

}
