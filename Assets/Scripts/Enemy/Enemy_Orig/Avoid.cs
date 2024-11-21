using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Avoid : MonoBehaviour
{
    public Transform player;
    public static float moveSpeed = 5f;
    private Vector3 startPosition;
    public NavMeshAgent agent;


    void Start()
    {
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
//        find.player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, player.position) < 1.75f)
        {
            Debug.Log("Enemy reached player!");
        }
        agent.SetDestination(player.position);
    }



}
