using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
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
        BA_GameManager.gm.slowTimer += 15;
        Destroy(gameObject);
    }


}
