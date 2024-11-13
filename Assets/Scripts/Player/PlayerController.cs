using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    public Vector3 home;

    public float pSpeed; // float was originally int
    public float jumpPower; // float was originally int
    public float gravity; // float was originally int

    private bool isGrounded;
    private bool hasCoyoted = false;
    private float lastGroundedTime = float.NegativeInfinity;
    private float jumpInputTime = float.NegativeInfinity;

    public Rigidbody rb;
    public LayerMask groundMask;

    //    public Vector2 input;
    Vector3 dampenVelocity;
    Vector2 dampenAirVelocity;

    public float airControlMultiplier = 1.6f;
    public float maxSpeed = 10f;

    [SerializeField] private Camera camera;

    public ObservedTransform playerTransform;
    void Awake()
    {
        playerTransform.transform = transform;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (camera == null)
        {
            camera = Camera.main;
        }
        if (camera == null)
        {
            camera = FindObjectOfType<Camera>();
        }
        home = new Vector3(5f, 1f, 5f);
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    Vector3 currentVelocity;
    private void Movement()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 inputTransformed = camera.transform.TransformDirection(input);
        inputTransformed.y = 0f;
        input = inputTransformed.normalized * input.magnitude;

        if (input.magnitude > 1)
        {
            input.Normalize();
        }
        //        input.y = rb.velocity.y;
        //        rb.velocity = input * pSpeed * Time.deltaTime;
        input *= pSpeed * Time.deltaTime;

        if (isGrounded)
        {
            //...the 15f is optional and sets max speed
            rb.velocity = Vector3.SmoothDamp(rb.velocity, new Vector3(input.x, rb.velocity.y, input.z), ref currentVelocity, 0.1f, 15f);

            dampenAirVelocity = Vector2.zero;
        }
        else
        {
            dampenVelocity = Vector3.zero;
            rb.AddForce(new Vector3(input.x, 0f, input.z) * airControlMultiplier, ForceMode.Acceleration); //if in air, force is added
            Vector2 xzMovement = new Vector2(rb.velocity.x, rb.velocity.z); // this affects horizontal movement
            if (rb.velocity.magnitude > maxSpeed)
            {
                xzMovement = Vector2.SmoothDamp(xzMovement, xzMovement.normalized * maxSpeed, ref dampenAirVelocity, 0.1f);// this clamps the movement in previous line
                                                                                                                           //Vector2.ClampMagnitude(xzMovement, maxSpeed); 
                rb.velocity = new Vector3(xzMovement.x, rb.velocity.y, xzMovement.y);
            }
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpInputTime = Time.time;
        }
        if (isGrounded || !hasCoyoted && (Time.time - lastGroundedTime) < 0.5f)
        {
            if ((Time.time - jumpInputTime) < 0.5f)
            {
                hasCoyoted = true;
                lastGroundedTime = float.NegativeInfinity;
                jumpInputTime = float.NegativeInfinity;
                rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange); //velocity change ignores gameobjects mass
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        hasCoyoted = false;
    }
    private void OnCollisionStay(Collision collision) //
    {
        int goLayer = 1 << collision.gameObject.layer;

        if ((groundMask & goLayer) != 0)
        {

            isGrounded = true;
            lastGroundedTime = Time.time;
        }
        else
        {
            isGrounded = false;
        }

        /*        if (collision.gameObject.layer == groundMask)
                {
                    Debug.Log("hit");
                }
                else
                {
                    Debug.Log("not hit");
                }

                Debug.Log("GO:" + collision.gameObject.layer);
                Debug.Log("Mask:" + groundMask.value);*/
    }

    private void OnCollisionExit(Collision collision)
    {
        int goLayer = 1 << collision.gameObject.layer;
        if ((groundMask & goLayer) != 0)
        {
            Debug.Log("Grounded");
            isGrounded = false;
        }
    }

    /*public bool IsGrounded()
    {

    }*/

    public void SendHome()
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(home, out hit, 10f, NavMesh.AllAreas))
        {
            agent.Warp(hit.position);
        }
        transform.position = home;

    }
}
