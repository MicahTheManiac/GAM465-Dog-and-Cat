using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : Activator
{

    // Collision Detection
    public abstract void OnTriggerEnter(Collider other);

    public abstract void OnTriggerExit(Collider other);
}