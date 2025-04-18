using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Character Controller
    public CharacterController controller;

    // Movement Values
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    // Grounding
    public float groundDistance = 0.2f;
    public Transform groundCheck;
    public LayerMask groundMask;

    // Private Vars
    private float _speedMultiplier = 1f;
    private bool _isGrounded = false;
    private Vector3 _velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check if we are grounded
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Set Velocity to Zero to Counteract Gravity
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y  = 0;
            Debug.Log("Grounded");
        }

        // Map Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * _speedMultiplier * Time.deltaTime);

        // Jumping (Make it Continuous, i.e. hold to jump)
        if (Input.GetButton("Jump") && _isGrounded)
        {
            // Eq: SQRT(h * -2 * g)
            _velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        //TODO: Add Sprint if Needed

        // Gravity is multiplied by Time^2, so multiply again in Move()
        _velocity.y += gravity * Time.deltaTime;

        controller.Move(_velocity * Time.deltaTime);
    }
}
