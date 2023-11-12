using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 2.0f;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public Vector3 respawnPoint;

    private Vector3 direction;
    private Rigidbody rb;
    private Transform cameraTransform;
    private bool jump = false;
    private bool isGrounded;
    private bool canJump = true; // New variable to control if the player can jump

    void Start()
    {
        cameraTransform = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position; // Set the respawn point to the initial position
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Take the forward vector of the camera and turn it into a direction for the player
        direction = cameraTransform.forward;
        direction.y = 0;
        direction = direction.normalized;

        Vector3 movement = (direction * moveVertical) + (cameraTransform.right * moveHorizontal);

        rb.AddForce(movement * speed);

        // Use a Physics check to see if we are on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
            jump = true;
            canJump = false; // Player can't jump again until the coroutine finishes
            StartCoroutine(EnableJump());
        }

        if (transform.position.y < -10)
        {
            Respawn();
        }
    }

    IEnumerator EnableJump()
    {
        yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds
        canJump = true; // Player can jump again
    }

    void FixedUpdate()
    {
        if(jump)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            jump = false;
        }
    }

    void Respawn()
    {
        // Set the player's position to a point above the respawn point
        transform.position = respawnPoint + new Vector3(0, 10, 0);

        // Ensure the player's velocity is reset so they fall straight down
        rb.velocity = Vector3.zero;
    }
}
