using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Vector3 gravity;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    public float mouseSensitivy = 5.0f;
    public float jumpHeight = 1.5f;
    private float gravityValue = -9.81f;
    
    private CharacterController controller;
    
    Animator animator;

    public float walkSpeed = 2;
    private float runSpeed = 8;

    private bool canDoubleJump = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        UpdateRotation();
        ProcessMovement();
        updateAnimation();
        
    }
    void UpdateRotation()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivy, 0, Space.Self);

    }

    public void ProcessMovement()
    {
        // Moving the character forward according to the speed
        float speed = GetMovementSpeed();

        // Get the camera's forward and right vectors
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // Make sure to flatten the vectors so that they don't contain any vertical component
        cameraForward.y = 0;
        cameraRight.y = 0;

        // Normalize the vectors to ensure consistent speed in all directions
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the movement direction based on input and camera orientation
        Vector3 moveDirection = (cameraForward * Input.GetAxis("Vertical")) + (cameraRight * Input.GetAxis("Horizontal"));

        // Apply the movement direction and speed
        Vector3 movement = moveDirection.normalized * speed * Time.deltaTime;

        Jump();

        // Apply gravity and move the character
        playerVelocity = gravity * Time.deltaTime + movement;
        controller.Move(playerVelocity);
    }

    public void DoubleJump() 
    {
        canDoubleJump = true;

    }

    public void Jump()
    {
        groundedPlayer = controller.isGrounded;

        if(groundedPlayer)
        {
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("IsGrounded", false);
                // Debug.Log("Single Jump");
                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
            else
            {
                animator.SetBool("IsGrounded", true);
                // Dont apply gravity if grounded and not jumping
                gravity.y = -1.0f;
            }
        } else {
            if (Input.GetButtonDown("Jump") && canDoubleJump)
            {
                // animator.SetBool("IsGrounded", false);
                animator.SetBool("IsDoubleJump", true);
                // Debug.Log("Double Jump");
                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                canDoubleJump = false;
            }else{
                // animator.SetBool("IsGrounded", false);
                animator.SetBool("IsDoubleJump", false);
                gravity.y += gravityValue * Time.deltaTime;
            }
        }
    }

    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }


    public void updateAnimation()
    { 
        Vector3 horizontalMove = playerVelocity;
        horizontalMove.y = 0;
        
        if (horizontalMove != Vector3.zero)
            animator.SetFloat("Speed", GetMovementSpeed() / runSpeed);
        else
            animator.SetFloat("Speed", 0);

    
    }
}
