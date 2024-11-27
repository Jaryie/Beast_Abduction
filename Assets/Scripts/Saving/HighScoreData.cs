using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class HighScoreData
{

    public float[] scores;
    public string[] names;

    public TMP_InputField input;
    public HighScoreData()    //Constructor 
    {
        scores = new[] {5f, 3f, 2f, 1f};
//        names = new[] {"Blinky", "Pinky", "Inky", "Clyde"};

        string name = input.name;
}

    public HighScoreData(float[] scores, string[] names)
    {
        this.scores = scores;
        this.names = names;
    }

}