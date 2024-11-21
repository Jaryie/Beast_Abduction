using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : NavMeshMove
{
    public float changeDirectionTime;
    float changeDirectionTimer;
    public float walkRadius;
    void Update()
    {
        if (agent.hasPath)
            return;
        if(changeDirectionTimer > 0)
        {
            changeDirectionTimer -= Time.deltaTime;
        }
        else
        {
            changeDirectionTimer = changeDirectionTime;
            Vector3 newDestination = transform.position + Random.insideUnitSphere * walkRadius;
            Move(newDestination);
        }
    }
}
