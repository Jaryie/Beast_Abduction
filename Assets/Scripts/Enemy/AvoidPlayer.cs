using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AvoidPlayer : NavMeshMove
{
    public ObservedTransform playerTransform;
    public float runRadius;
    public float runDistance;
    void Update()
    {
        Vector3 vectorToPlayer = playerTransform.transform.position - transform.position;
        if(vectorToPlayer.magnitude < runRadius)
        {
            Move(playerTransform.transform.position - vectorToPlayer.normalized*runDistance);
        }
    }
}