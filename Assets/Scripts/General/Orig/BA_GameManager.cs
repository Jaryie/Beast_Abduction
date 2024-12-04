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
    public float runSpeed;

    public int captured;
    public int total;
    public float previousCapturedAttained;

    private bool win;
    public bool counted;

    [SerializeField] private Canvas winCanvas;

    private void Awake()
    {
        Application.targetFrameRate = 180;
        win = false;
        counted = false;
        winCanvas.gameObject.SetActive(false);
    }

    void Start()
    {
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

        WinCondition();

    }

    public void TakeCaptured()
    {
        captured = 0;
        //        DebugLog.Warning("The Cops have confiscated your kills");
    }

     public void Freeze()
    {
        runSpeed = 0;
    }

    public void Slow()
    {
        runSpeed = runSpeed / 2f;
    }

    void WinCondition()
    {
        if (total == 0 && counted == true)
        {
            Debug.LogWarning("WinCondition");
            win = true;
            winCanvas.gameObject.SetActive(true);
        }
    }
}
