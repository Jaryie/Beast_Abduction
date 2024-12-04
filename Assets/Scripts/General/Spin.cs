using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 145 * Time.deltaTime, 0);
    }
}
