using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using System.Runtime.CompilerServices;
using System.Linq;

public class HighScoreSystem : MonoBehaviour
{
    private List<string> names = new List<string>();
    private List<float> scores = new List<float>();

    public TMP_InputField input;
    string name;

    public int maxScores = 10;

    public Transform panel;
    public TMP_Text textPrefab;
    [SerializeField] public TMP_Text scorePrefab;

    public Display_Monster displayMonster;
    //    public HighScoreData data;
    public static HighScoreSystem instance;

    private void Awake()
    {
//        name = input.text;

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        displayMonster = FindObjectOfType<Display_Monster>();

        HighScoreData data = JsonSaveLoad.LoadHighScore();
        if (data != null)
        {
            names = data.names.ToList();
            scores = data.scores.ToList();
        }
        RefreshScoreDisplay();
    }

    private void OnDestroy()
    {
        HighScoreData data = new HighScoreData(scores.ToArray(), names.ToArray());
        JsonSaveLoad.SaveHighScore(data);
    }

    private void RefreshScoreDisplay()
    {
        for (int i = panel.childCount - 1; i >= 0; i--)
        { Destroy(panel.GetChild(i).gameObject); }
        for (int i = 0; i < scores.Count; i++)
        {
            TMP_Text text = Instantiate(textPrefab, panel);
            text.text = names[i];
            text = Instantiate(textPrefab, panel);
            text.text = scores[i].ToString();
        }
    }

    //   string[] possibleNames = { "Blinky", "Pinky", "Inky", "Clyde" };


    public void NewScore(int score)
    {
        NewScore(names[Random.Range(0, names.Count)], score);
    }

    public void NewScore(string name, int score)
    {
        for (int index = 0; index < scores.Count; index++)
        {
            if (score < scores[index])
            {
                scores.Insert(index, score);
                names.Insert(index, name);
                RefreshScoreDisplay();
                if (scores.Count > maxScores)
                {
                    scores.RemoveAt(scores.Count - 1);
                    names.RemoveAt(names.Count - 1);
                }
                return;
            }
        }
        if (scores.Count < maxScores)
        {
            scores.Add(score);
            names.Add(name);
            RefreshScoreDisplay();
        }
    }

    public void EnterName(string name)
    {
        NewScore(name, displayMonster.GetComponent<Display_Monster>().GetScore());
        Debug.Log("EnterName: " + name);

    }

}
