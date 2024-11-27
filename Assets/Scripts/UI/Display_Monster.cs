using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;

public class Display_Monster : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] TMP_Text capturedText;
    [SerializeField] TMP_Text totalText;
    GameObject[] hunt; 
    //TODO: Change this to a list, add and remove from list during gameplay
    // you can use List.Remove(type)

    private int captured;
    private int total;

    private void Start()
    {
        hunt = GameObject.FindGameObjectsWithTag("Hunt");
    }

    void Update()
    {
        hunt = GameObject.FindGameObjectsWithTag("Hunt");

        captured = BA_GameManager.gm.captured;
        capturedText.text = captured.ToString();

        BA_GameManager.gm.total = hunt.Length;
        total = BA_GameManager.gm.total;
        totalText.text = total.ToString();
    }
}
