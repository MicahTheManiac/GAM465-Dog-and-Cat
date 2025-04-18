using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    // Character Controller
    public CharacterController controller;
    public Transform camera;

    // Movement Values
    public float speed = 6f;
    public float smoothness = 0.1f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    // Grounding
    public float groundDistance = 0.1f;
    public Transform groundCheck;
    public LayerMask groundMask;

    // Private Variables
    private float _turnSmoothVelocity;
    private bool _isGrounded = false;
    private Vector3 _velocity;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Get Is Grounded
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Set Velocity to Zero to Counteract Gravity
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = 0;
            if (timer != -1f)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer = 10f;
                    Debug.Log("Is Grounded!");
                }
            }
        }
        else
        {
            timer = 0f;
        }

        // Map Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(x, 0f, z).normalized;

        if (direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, smoothness);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        // Jumping (Make it Continuous, i.e. hold to jump)
        if (Input.GetButton("Jump") && _isGrounded)
        {
            // Eq: SQRT(h * -2 * g)
            _velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Gravity is multiplied by Time^2, so multiply again in Move()
        _velocity.y += gravity * Time.deltaTime;

        controller.Move(_velocity * Time.deltaTime);
    }
}
