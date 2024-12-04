using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    public static float timer;
    bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        BA_GameManager.gm.Slow();
        BA_GameManager.gm.slowTimer += 10;
        Destroy(gameObject);
    }
}
