using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurn : MonoBehaviour
{
    public float turningSpeed;
    Vector2 turn;
    void Update()
    {
        turn.x = Input.GetAxis("Horizontal")*Time.deltaTime*turningSpeed;
        transform.forward = transform.forward + transform.right * turn.x;
    }
}
