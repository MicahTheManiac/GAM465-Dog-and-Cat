using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualActivator : Activator
{
    public Activator activator1;
    public Activator activator2;
    public bool doAndGate = false;
    public bool doStayActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doAndGate)
        {
            if (activator1.isActive && activator2.isActive)
            {
                isActive = true;
            }
            else if (!doStayActive)
            {
                isActive = false;
            }
        }
        else
        {
            if (activator1.isActive || activator2.isActive)
            {
                isActive = true;
            }
            else if (!doStayActive)
            {
                isActive = false;
            }
        }
    }
}
