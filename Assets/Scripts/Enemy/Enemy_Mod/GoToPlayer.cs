using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayer : NavMeshMove
{
    public float detectionRadius;
    void Update()
    {
        Vector3 vectorToPlayer = ObservedTransform.transform.position - transform.position;
        if (vectorToPlayer.magnitude < detectionRadius)
        {
            Move(ObservedTransform.transform.position);
        }
    }
}
