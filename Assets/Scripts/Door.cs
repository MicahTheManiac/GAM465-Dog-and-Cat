using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Model and Activator
    public GameObject model;
    public Activator activator;

    // Do Start Active
    public bool doStartActive = false;

    // Private Vars
    private bool _isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        if (doStartActive)
        {
            _isActive = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get the Collider and Renderer from the Model (Door)
        Collider collider = model.GetComponent<Collider>();
        MeshRenderer renderer = model.GetComponent<MeshRenderer>();

        // If we are Active, Disable Door
        if (_isActive)
        {
            collider.enabled = false;
            renderer.enabled = false;
        }
        else
        {
            collider.enabled = true;
            renderer.enabled = true;
        }

        // Get Activator
        if (activator != null)
        {
            // Get Active State
            if (activator.isActive)
            {
                // If we Started Active
                if (doStartActive)
                {
                    _isActive = false;
                }
                else
                {
                    _isActive = true;
                }
            }
            else
            {
                // If we Started Active
                if (doStartActive)
                {
                    _isActive = true;
                }
                else
                {
                    _isActive = false;
                }
            }
        }
    }
}
