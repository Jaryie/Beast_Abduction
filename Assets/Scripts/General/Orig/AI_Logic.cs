using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AI_Logic : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent _agent;

    GameObject test;
    Vector3 startPosition;

    public Wander randomWalk;
    public Avoid runAway;
    public Hunt grabThese;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
    }
}
