using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{
    public Transform netGO;
    public Transform playerGO;
    public Collider netCollider;
    public float speed = 4.0f;
    public float currentTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 upDir = Vector3.up;
            Vector3 forwardDir = playerGO.transform.forward;

            netGO.rotation = Quaternion.LookRotation(forwardDir, upDir);
            currentTime = 0.0f;
            //netCollider.enabled = true;
        }
        
        if (Input.GetMouseButton(0))
        {
            Plane plane = new Plane(Vector3.up, netGO.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 targetPos = Vector3.zero;

            if (plane.Raycast(ray, out float distance))
            {
                targetPos = ray.GetPoint(distance);
            }

            Vector3 upDir = Vector3.up;
            Vector3 forwardDir = playerGO.transform.forward;// targetPos - netGO.position;

            Quaternion upRotation = Quaternion.LookRotation(forwardDir, upDir);
            Quaternion forwardRotation = Quaternion.LookRotation(-upDir, forwardDir);

            currentTime += Time.deltaTime * speed;

            netGO.rotation = Quaternion.Lerp(upRotation, forwardRotation, currentTime);

     /*       if (currentTime >= 1.2f)
            {
                netCollider.enabled = false;
            }*/
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " caught by net");
        if (other.tag == "Hunt")
        {
            StartCoroutine(Capture(other.gameObject));
        }
    }

    IEnumerator Capture(GameObject hunt)
    {
        float captureTime = 0;
        while (captureTime < 1.0f)
        {
            float wave = Mathf.Sin(Time.time * 20f) * 0.1f + 1f;
            float wave2 = Mathf.Cos(Time.time * 20f) * 0.1f + 1f;
            netGO.localScale = new Vector3(wave, wave2, wave);

            float reduce = 2.4f * Time.deltaTime;

            if (hunt != null && hunt.transform.localScale.x > 0.1f)
            {
                hunt.transform.localScale = new Vector3(hunt.transform.localScale.x - reduce,
                    hunt.transform.localScale.y - reduce,
                    hunt.transform.localScale.z - reduce);
            }
            else
            {
                Destroy(hunt);
            }
            captureTime += Time.deltaTime;
            yield return null;
        }
        netGO.localScale = Vector3.one;
    }

}
