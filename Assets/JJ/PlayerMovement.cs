using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;
    public float airMultiplier = 0.5f;
    public float dragWhileMoving = 5f;
    public int maxJumps = 2;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;
    public bool moving;

    public Transform orientation;

    float horizontalInput;
    bool readyToJump;
    int jumps;
    private Animator animator;

    [HideInInspector]
    public bool onJumpLeaf; // Change the access modifier to public

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (grounded)
            rb.drag = dragWhileMoving;
        else
            rb.drag = 0;

        if (Input.GetKeyDown(jumpKey) && readyToJump)
        {
            Jump();
        }

        // Check if the player is moving
        moving = Mathf.Abs(horizontalInput) > 0.1f;

        // Set a bool in the animator to control movement animation
        animator.SetBool("Moving", moving);
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = orientation.forward * horizontalInput;

        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else
        {
            // Apply a force in the direction of input without normalizing
            rb.AddForce(moveDirection * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void Jump()
    {
        if (grounded || jumps < maxJumps || onJumpLeaf)
        {
            float modifiedJumpForce = onJumpLeaf ? jumpForce * 2f : jumpForce;
            rb.AddForce(transform.up * Mathf.Sqrt(modifiedJumpForce * -2f * Physics.gravity.y), ForceMode.Impulse);
            readyToJump = false;
            jumps++;

            onJumpLeaf = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        readyToJump = true;
        jumps = 0;

        if (collision.gameObject.CompareTag("JumpLeaf"))
        {
            onJumpLeaf = true;
        }
    }
}
