using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }
}
