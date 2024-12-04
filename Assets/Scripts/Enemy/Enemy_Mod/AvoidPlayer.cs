using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
public class AvoidPlayer : NavMeshMove
{
    [System.Serializable]
    public enum State
    {
        Idle,
        Walk,
        Run,
    }
    public State state = State.Idle;
    public float runRadius;
    public float runDistance;
    public float runSpeed;

    void Update()
    {
        switch (state)
        {
            case State.Idle:
                StartCoroutine(IdleState());
                break;
            case State.Walk:
                StartCoroutine(WalkState());
                break;
            case State.Run:
                StartCoroutine(RunState());
                break;
            default:
                break;
        }
    }
    IEnumerator RunState()
    {
        while (state == State.Run)
        {
            Vector3 vectorToPlayer = ObservedTransform.transform.position - transform.position;
            if (vectorToPlayer.magnitude < runRadius)
            {
                Move(ObservedTransform.transform.position - vectorToPlayer.normalized * runDistance * runSpeed);
            }

            if (vectorToPlayer.magnitude > runRadius * 2)
            {
                state = State.Idle;
            }
            yield return null;
        }
    }
    IEnumerator WalkState()
    {
        while (state == State.Walk)
        {
            if (agent.hasPath)
            {
                Vector3 newDestination = transform.position + Random.insideUnitSphere * runRadius * (runSpeed/1.5f);
                Move(newDestination);
            }
            yield return null;
        }
    }

    IEnumerator IdleState()
    {
        while (state == State.Idle)
        {
            yield return null;
        }
    }


    private void OnDestroy()
    {
        BA_GameManager.gm.captured += 1;

    }
}