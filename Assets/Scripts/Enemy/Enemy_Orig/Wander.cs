using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Wander : MonoBehaviour
{
    public Transform player;
    public static float mSpeed = 5f;
    private Vector3 startPosition;
    public NavMeshAgent _Agent;
    public float _Range = 25.0f;
    private MaterialPropertyBlock propertyBlock;
    private Renderer renderer1;

    void Awake()
    {
        renderer1 = GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();
        PickRandom();
    }
    void Start()
    {
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _Agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        Vector3 randomPosition = _Range * Random.insideUnitCircle;
        randomPosition = new Vector3(randomPosition.x, 0, randomPosition.z);
        _Agent.destination = (transform.position + randomPosition) * mSpeed;

        /*if (Vector3.Distance(transform.position, player.position) < 1.75f)
        {
            Debug.Log("Enemy reached player!");
            //            player.GetComponent<PlayerController>()?.SendHome();
        }

        if (_Agent.pathPending || !_Agent.isOnNavMesh || _Agent.remainingDistance > 0.1f)
        {
            return;   // exit function (update) here
        }*/

        PickRandom();
        SlideColor();
    }

    public void PickRandom()
    {
        Color randomColor = Random.ColorHSV();
        propertyBlock.SetColor("_Color", randomColor);
        renderer1.SetPropertyBlock(propertyBlock);
    }

    private float H = 0;
    public void SlideColor()
    {
        H += 0.1f * Time.deltaTime;
        Debug.Log(H);
        if (H >= 1)
        {
            H = 0;
        }
        Color newColor = Color.HSVToRGB(H, 1, 1);
        propertyBlock.SetColor("_Color", newColor);
        renderer1.SetPropertyBlock(propertyBlock);
    }


}
