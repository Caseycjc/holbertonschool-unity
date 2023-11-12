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
    private bool canJump = true; 
    private Animator anim;
    private float fallingTime = 0f;


    void Start()
    {
        cameraTransform = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Use camera forward for direction
        Vector3 moveDirection = cameraTransform.forward * moveVertical + cameraTransform.right * moveHorizontal;
        moveDirection.y = 0; 
        moveDirection.Normalize();

        rb.AddForce(moveDirection * speed);

        // Character Rotation to Face Movement Direction
        if (moveDirection != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        }

        // Animation Handling
        bool isMoving = moveDirection.magnitude > 0.1f;
        anim.SetBool("IsMoving", isMoving);

        // Ground Check and Jumping Logic
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // Falling Logic
        if (!isGrounded && rb.velocity.y < 0)
        {
            fallingTime += Time.deltaTime;  // Increment the falling time

            if(fallingTime >= 1f)
            {
                Debug.Log("Character is Falling!");
                anim.SetBool("IsFalling", true);
            }
}
else
{
    fallingTime = 0f;  // Reset the falling time
    anim.SetBool("IsFalling", false);
}

        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
            jump = true;
            anim.SetBool("IsJumping", true); 
            canJump = false;
            StartCoroutine(EnableJump());
            isGrounded = false;
        }

        if (isGrounded)
        {
            anim.SetBool("IsJumping", false);
            Debug.Log("Character is Grounded!");
        }

        // Respawn Logic
        if (transform.position.y < -10)
        {
            Respawn();
        }
    }

    IEnumerator EnableJump()
    {
        yield return new WaitForSeconds(0.1f); 
        canJump = true;
    }

    void FixedUpdate()
    {
        if (jump)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            jump = false;
        }
    }

    void Respawn()
    {
        transform.position = respawnPoint + new Vector3(0, 10, 0);
        rb.velocity = Vector3.zero;
    }
}
