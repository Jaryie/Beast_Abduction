using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Boost : ScriptableObject
{
    public float timeLeft;
    public float activationTime;
    public bool activated => timeLeft > 0;
    public virtual void Activate()
    {
        timeLeft = activationTime;
    }
}
