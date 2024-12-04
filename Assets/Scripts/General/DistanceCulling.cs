using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DistanceCulling : MonoBehaviour
{
    public float cullingDistance = 50f;
    bool playerExists;
    public MeshRenderer[] renderers;
    public Collider[] colliders;
    public MonoBehaviour[] scripts;
    public NavMeshAgent[] agents;
    void Start()
    {
        playerExists = ObservedTransform.transform != null;
    }
    void Update()
    {
        bool cull = false;
        if (Vector3.SqrMagnitude(ObservedTransform.transform.position - transform.position) > cullingDistance * cullingDistance)
        {
            cull = true;
        }
        foreach (Collider collider in colliders)
        {
            if(collider == null) continue;
            collider.enabled = !cull;
        }
        foreach (MeshRenderer renderer in renderers)
        {
            if (renderer == null) continue;
            renderer.enabled = !cull;
        }
        foreach (MonoBehaviour script in scripts)
        {
            if (script == null) continue;
            script.enabled = !cull;
        }
        foreach (NavMeshAgent agent in agents)
        {
            if (agent == null) continue;
            agent.enabled = !cull;
        }
    }
}