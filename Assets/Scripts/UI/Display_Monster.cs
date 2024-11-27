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
    GameObject[] hunt = GameObject.FindGameObjectsWithTag("Hunt");

    private int captured;
    private int total;


    void Update()
    {
        captured = BA_GameManager.gm.captured;
        capturedText.text = captured.ToString();

        BA_GameManager.gm.total = hunt.Length;
        total = BA_GameManager.gm.total;
        totalText.text = total.ToString();
    }
}
