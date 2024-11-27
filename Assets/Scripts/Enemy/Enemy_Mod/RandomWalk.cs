using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : NavMeshMove
{
    public float changeDirectionTime;
    float changeDirectionTimer;
    public float walkRadius;
    Vector3 startPosition;
    public float bounceHeight;
    public AnimationCurve bounceCurve;
    public float bounceSpeed;
    float curveTime;

    enum State
    {
        Idle,        
        Walk,
        Bounce
    }

    State state = State.Walk;

    private void Start()
    {
    startPosition = transform.position;         
    }

    void Update()
    {
        switch (state)
        {
            case State.Idle:
                StartCoroutine(WalkState());
                break;
            case State.Walk:
                StartCoroutine(IdleState());
                break;
            case State.Bounce:
                StartCoroutine(BounceState());
                break;
            default:
                break;
        }    
    }

    IEnumerator WalkState()
    {
        while (state == State.Walk)
        {
            changeDirectionTimer = changeDirectionTime;
            Vector3 newDestination = transform.position + Random.insideUnitSphere * walkRadius;
            Move(newDestination);
        }
        yield return null;
    }

    IEnumerator IdleState()
    {
        while (state == State.Idle)
        {
            changeDirectionTimer -= 1;
        }
            yield return null; 
    }
    IEnumerator BounceState()
    {
        while (state == State.Bounce)
        {
            transform.position = startPosition + Vector3.up * bounceHeight * bounceCurve.Evaluate(curveTime); 
            curveTime += Time.deltaTime * bounceSpeed; 
            if (curveTime > 1) 
            {
                curveTime = 0; 
            }
        }
        yield return null; 
    }
}
