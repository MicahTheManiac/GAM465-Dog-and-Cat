using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Goal : Activator
{
    // Activator
    public Activator activator;

    // Indicators
    public GameObject indicatorOff;
    public GameObject indicatorOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isActive = activator.isActive;
        SetIndicator(isActive);
    }

    private void SetIndicator(bool status)
    {
        indicatorOff.SetActive(!status);
        indicatorOn.SetActive(status);
    }
}
