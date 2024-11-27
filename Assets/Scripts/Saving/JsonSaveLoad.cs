using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class JsonSaveLoad
{
#if UNITY_EDITOR
    public static string fileHS = Application.dataPath + "/save.json";
//    public static string filePos = Application.dataPath + "/savePos.json";
#else
    public static string fileHS = Application.persistentDataPath + "/saveHS.json";
 //   public static string filePos = Application.persistentDataPath + "/savePos.json";
#endif


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
