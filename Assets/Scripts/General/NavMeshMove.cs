using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if (agent == null) return;
        NavMeshHit hit;
        if(NavMesh.SamplePosition(p, out hit, 30f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}
