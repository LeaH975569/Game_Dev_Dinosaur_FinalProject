using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6.0f;   // Speed at which the player moves forward and backward
    public float jumpForce = 8.0f;   // Force applied when jumping

    private Animator animator;

    private CharacterController controller;
        

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        // Move forward
        if (Input.GetKey(KeyCode.W))
        {
            controller.Move (Vector3.forward * moveSpeed * Time.deltaTime);
            animator.SetTrigger("Run");
            Debug.Log("You have clicked w!");
        }
        // Move backward
        else if (Input.GetKey(KeyCode.S))
        {
            controller.Move(Vector3.back * moveSpeed * Time.deltaTime);
            animator.SetTrigger("Run");
        }
 
        // Jump if the player is grounded and Space key is pressed
        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            controller.Move(Vector3.back * moveSpeed * Time.deltaTime);
            animator.SetTrigger("Jump");
        }
    }
}
