using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Trigger
{
    // Get Model
    public GameObject model;
    public Collider objectToCheck;

    // Private Variables
    private Vector3 _position;

    // Start is called before the first frame update
    void Start()
    {
        if (model != null)
        {
            _position = model.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnTriggerEnter(Collider other)
    {
        // Do Check for Object
        if (objectToCheck != null && other == objectToCheck)
        {
            Activate(true);
        }
        // Else Object is Null, Behave normally
        else if (objectToCheck == null)
        {
            Activate(true);
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        // Do Check for Object
        if (objectToCheck != null && other == objectToCheck)
        {
            Activate(false);
        }
        // Else Object is Null, Behave normally
        else if (objectToCheck == null)
        {
            Activate(false);
        }
    }

    private void SetModel(Vector3 position)
    {
        if (model != null)
        {
            model.transform.position = position;
        }
    }

    private void Activate(bool status)
    {
        if (status)
        {
            isActive = true;
            SetModel(new Vector3(_position.x, _position.y - 0.05f, _position.z));
        }
        else
        {
            isActive = false;
            SetModel(_position);
        }
    }
}
