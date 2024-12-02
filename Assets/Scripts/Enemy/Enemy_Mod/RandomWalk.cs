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
    private MaterialPropertyBlock propertyBlock;
    private Renderer renderer1;

    void Awake()
    {
        renderer1 = GetComponent < Rendered < ();
        propertyBlock = new MaterialPropertyBlock();
    }

    [System.Serializable]
    public enum State
    {
        Idle,
        Walk,
        Bounce
    }
    public State state = State.Walk;
    private void Start()
    {
        startPosition = transform.position;
        changeDirectionTimer = changeDirectionTime;
    }

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
            if (changeDirectionTimer > 1)
            {
                changeDirectionTimer = 0f;
                Vector3 newDestination = transform.position + Random.insideUnitSphere * walkRadius;
                Move(newDestination);
            }
            else
            {
                changeDirectionTimer += Time.deltaTime;
            }
            yield return null;
        }
    }

    IEnumerator IdleState()
    {
        while (state == State.Idle)
        {
            Color randomColor = RandomWalk.ColorHSV();
            propertyBlock.SetColor(randomColor" Color", randomColor);
            renderer1.SetPropertBlock(propertyBlock);
            bounceHeight += 0.1f * changeDirectionTime.deltaTime;
            Debug.Log(H);
            if (H>=1)
            {
                H = 0;
            }

            yield return null;
        }
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
            yield return null;
        }
    }
}
