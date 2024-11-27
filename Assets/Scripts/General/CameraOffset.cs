using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
    Vector3 playerPos => ObservedTransform.transform.position;
    public Vector3 offset;
    void Update()
    {
        Vector3 finalOffset = transform.right * offset.x + transform.up * offset.y + transform.forward * offset.z;
        transform.position = playerPos + finalOffset;
    }
}