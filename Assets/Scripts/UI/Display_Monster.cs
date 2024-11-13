using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Display_Monster : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] TMP_Text capturedText;
    [SerializeField] TMP_Text totalText;

    private float captured;
    private float total;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        captured = BA_GameManager.gm.captured;
        capturedText.text = captured.ToString();
        total = BA_GameManager.gm.total;
        totalText.text = total.ToString();
    }
}
