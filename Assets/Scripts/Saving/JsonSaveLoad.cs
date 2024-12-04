using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class JsonSaveLoad
{

    public static string fileHS = Application.dataPath + "/save.json";
/*    public static string filePos = Application.dataPath + "/savePos.json";

    public static string fileHS = Application.persistentDataPath + "/saveHS.json";
   public static string filePos = Application.persistentDataPath + "/savePos.json";*/



    public static void SaveHighScore(HighScoreData data)
    {
        string json = JsonUtility.ToJson(data, true); //true makes the file more human readable
        File.WriteAllText(fileHS, json);
    }


    public static HighScoreData LoadHighScore()
    {
        if (File.Exists(fileHS))
        {
            string json = File.ReadAllText(fileHS);
            return JsonUtility.FromJson<HighScoreData>(json);
        }

        return null;
    }
}
