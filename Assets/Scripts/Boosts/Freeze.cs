using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public static float timer;
    bool activated = false;

    private void OnTriggerEnter (Collider other)
    {
        BA_GameManager.gm.Freeze();
        BA_GameManager.gm.freezeTimer += 15;
        Destroy(gameObject);
    }
}
