using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMove : MonoBehaviour
{
    protected NavMeshAgent agent;
    public virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public virtual void Move(Vector3 p)
    {
        NavMeshHit hit;
        if(NavMesh.SamplePosition(p, out hit, 30f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}
