using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;
    public float airMultiplier = 0.5f; // Adjust air movement multiplier
    public float dragWhileMoving = 5f; // Adjust ground drag while moving
    public int maxJumps = 2; // Adjust the maximum number of jumps

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

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // ground check
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

        // Set drag while moving
        if (grounded)
            rb.drag = dragWhileMoving;
        else
            rb.drag = 0;

        // when to jump
        if (Input.GetKeyDown(jumpKey) && readyToJump)
        {
            Jump();
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        Vector3 moveDirection = orientation.forward * horizontalInput;

        // on ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

            if (moveDirection != Vector3.zero)
            {
                animator.SetBool("Moving", true);
            }
            else
            {
                animator.SetBool("Moving", false);
            }
        }
        // in air
        else
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            animator.SetBool("Moving", false);
        }
    }

    private void Jump()
    {
        if (grounded || jumps < maxJumps)
        {
            rb.AddForce(transform.up * Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y), ForceMode.Impulse);
            readyToJump = false;
            jumps++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        readyToJump = true;
        jumps = 0; // Reset jumps when landing
    }
}