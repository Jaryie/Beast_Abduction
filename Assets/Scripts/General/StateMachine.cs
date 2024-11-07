using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;
using UnityEngine.UI;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{

    public Transform player;


    public enum State
    {
        Idle,
        Patrol,
        Attack,
        Flee,
        Sleep,
        Chasing,
        Captured,
    }

    public State state;


    Rigidbody rb;

    private void Start()
    {
        NextState();
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerController>().transform;
    }

    void NextState()
    {
        switch (state)
        {
            case State.Sleep:
                StartCoroutine(SleepState());
                break;
            case State.Idle:
                StartCoroutine(IdleState());
                break;
            case State.Patrol:
                StartCoroutine(PatrolState());
                break;
            case State.Chasing:
                StartCoroutine(ChasingState());
                break;
            case State.Attack:
                StartCoroutine(AttackState());
                break;
            case State.Flee:
                StartCoroutine(FleeState());
                break;
            case State.Captured:
                StartCoroutine(CapturedState());
                break;
            default:
                Debug.LogError("State does not exist");
                break;
        }

        IEnumerator PatrolState()
        {
            Debug.Log("Entering Patrol State"); //Setup, entry point
            yield return new WaitForSeconds(1.5f);
            while (state == State.Patrol) //"Update() Loop"
            {
                /*              transform.rotation *= Quaternion.Euler(0f, 50f * Time.deltaTime, 0f);

                                Vector3 directionToPlayer = player.position - transform.position;
                                directionToPlayer.Normalize();

                                float result = Vector3.Dot(transform.right, directionToPlayer);

                                if (result > 0.95f)
                                {
                                    state = State.Chasing;
                                }*/
                transform.rotation *= Quaternion.Euler(0f, 45f * Time.deltaTime, 0f);
                Vector3 directionToPlayer = player.transform.position - transform.position; //direction from A to B = B - A = "B minus A"
                directionToPlayer.Normalize(); //Dot product parameters should be "normalized"
                float result = Vector3.Dot(transform.forward, directionToPlayer);

                if (result > 0.95f)
                {
                    state = State.Chasing;

                }


                yield return null; //wait for a frame
            }
            Debug.Log("Exiting Patrol State"); //exit point, tear down
            NextState();
        }


        IEnumerator ChasingState()
        {
            Debug.Log("Entering Chasing State"); //Setup, entry point
            yield return new WaitForSeconds(1.5f);
            float startTime = Time.time;
            while (state == State.Chasing)
            {
                float wave = Mathf.Sin(Time.time * 15f) * 0.1f + 1f;
                float wave2 = Mathf.Cos(Time.time * 15f) * 0.1f + 1f;
                transform.localScale = new Vector3(wave, wave2, wave);

                float shimmy = Mathf.Sin(Time.time * 30f) * 0.9f + 0.3f;
                //choose transformation movemnt or rigideboyd movement                
                //transform.position += transform.right * shimmy * Time.deltaTime * 3;
                rb.AddForce(transform.right * shimmy);

                /*                if (Time.time - startTime > 3f)
                                {
                                    state = State.Idle;
                                }*/

                Vector3 directionToPlayer = player.transform.position - transform.position; //direction from A to B = B - A = "B minus A"
                directionToPlayer.Normalize(); //Dot product parameters should be "normalized"

                float angle = Vector3.SignedAngle(transform.forward, directionToPlayer, Vector3.up);
                rb.AddForce(Vector3.forward * shimmy);

                if (angle > 0)
                {
                    transform.rotation *= Quaternion.Euler(0f, 50f * Time.deltaTime, 0f);
                }
                else
                {
                    transform.rotation *= Quaternion.Euler(0f, -50f * Time.deltaTime, 0f);
                }

                rb.AddForce(transform.forward * shimmy);

                if (directionToPlayer.magnitude < 2f)
                {
                    state = State.Attack;
                }


                yield return null;
            }
            Debug.Log("Exiting Chasing State"); //exit point, tear down, OnDestroy()
            NextState();
        }

        IEnumerator CapturedState()
        {
            Debug.Log("Entering Captured State"); //Setup, entry point
            yield return new WaitForSeconds(1.5f);



            Debug.Log("Exiting Captured State"); //exit point, tear down


        }


        IEnumerator SleepState()
        {
            Debug.Log("Entering Sleep State"); //Setup, entry point
            yield return new WaitForSeconds(1.5f);



            Debug.Log("Exiting Sleep State"); //exit point, tear down


        }

        IEnumerator IdleState()
        {
            Debug.Log("Entering Idle State"); //Setup, entry point
            float startTime = Time.time;
            while (state == State.Idle)
            {
                yield return new WaitForSeconds(0.1f);
                if (Time.time - startTime > 3f)
                {
                    state = State.Patrol;
                }
                yield return null;
            }
            Debug.Log("Exiting Idle State"); //exit point, tear down
            NextState();
        }

        IEnumerator AttackState()
        {
            Debug.Log("Entering Attack State"); //Setup, entry point

            while (state == State.Attack)
            {
                Vector3 directionToPlayer = player.transform.position - transform.position;
                if (directionToPlayer.magnitude > 3f)
                {

                }
                yield return new WaitForSeconds(1.5f);
            }

            Debug.Log("Exiting Attack State"); //exit point, tear down


        }

        IEnumerator FleeState()
        {
            Debug.Log("Entering Flee State"); //Setup, entry point
            yield return new WaitForSeconds(1.5f);



            Debug.Log("Exiting Flee State"); //exit point, tear down


        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}


