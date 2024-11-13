using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreData
{
    public float[] scores;
    public string[] names;
    public HighScoreData()    //Constructor 
    {
        scores = new[] {5f, 3f, 2f, 1f};
        names = new[] {"Blinky", "Pinky", "Inky", "Clyde"};
    }

    public HighScoreData(float[] scores, string[] names)
    {
        this.scores = scores;
        this.names = names;
    }

}
