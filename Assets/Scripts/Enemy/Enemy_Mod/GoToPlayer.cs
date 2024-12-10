using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class GoToPlayer : NavMeshMove
{
 //   IGetTarget targetingInterface;
    public float detectionRadius;
    public float runSpeed;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
 //       targetingInterface = GetComponent<IGetTarget>();
    }
    void Update()
    {
        Vector3 vectorToPlayer = ObservedTransform.transform.position - transform.position;
        if (vectorToPlayer.magnitude < detectionRadius)
        {
            Move(ObservedTransform.transform.position);
        }
    }
}
