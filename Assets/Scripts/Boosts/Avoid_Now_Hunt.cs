using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoid_Now_Hunt : MonoBehaviour
{
    public static float timer;
    bool activated = false;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        BA_GameManager.gm.changeTimer += 30;
        Destroy(gameObject);
    }
}
