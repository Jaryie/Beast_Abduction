using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hunt : MonoBehaviour
{
    public Transform player;
    public static float moveSpeed = 5f;
    public int value;
    public NavMeshAgent agent;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        transform.position = -(player.position - transform.position).normalized * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Beast Captured");
        if (BA_GameManager.gm.changeTimer > 0)
        {
            BA_GameManager.gm.captured += Mathf.Abs(value * 2);
        }
        else
        {
            BA_GameManager.gm.captured += value ;
        }
        Destroy(gameObject);
    }
}
