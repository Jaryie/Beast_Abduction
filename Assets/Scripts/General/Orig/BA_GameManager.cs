using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BA_GameManager : MonoBehaviour
{
    public static BA_GameManager gm;
    public float freezeTimer;
    public float slowTimer;
    public float changeTimer;

    public int captured;
    public int total;
    public float previousCapturedAttained;

    private bool win;

    [SerializeField] private Canvas winCanvas;

    void Start()
    {
        Application.targetFrameRate = 180;

        win = false;

        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(this);
        }
        captured = 0;

        previousCapturedAttained = PlayerPrefs.GetFloat("Captured");
    }

    void Update()
    {
        if (freezeTimer > 0)
        {
            freezeTimer -= Time.deltaTime;
        }

        if (slowTimer > 0)
        {
            slowTimer -= Time.deltaTime;
        }

        if (changeTimer > 0)
        {
            changeTimer -= Time.deltaTime;
        }
    }

    public void TakeCaputured()
    {
        captured = 0;
    }

    void WinCondition()
    {
        if (total <=0)
        {
            win = true;
            if (win = true)
            {
                winCanvas.enabled = true;
            }
        }
    }
}
