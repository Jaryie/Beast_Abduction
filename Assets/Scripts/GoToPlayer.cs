using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayer : NavMeshMove
{
    public ObservedTransform playerTransform;
    public float detectionRadius;
    void Update()
    {
        Vector3 vectorToPlayer = playerTransform.transform.position - transform.position;
        if (vectorToPlayer.magnitude < detectionRadius)
        {
            Move(playerTransform.transform.position);
        }
    }
}
