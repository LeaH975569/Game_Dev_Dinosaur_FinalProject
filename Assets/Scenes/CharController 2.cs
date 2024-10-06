using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController2 : MonoBehaviour
{
    public float speed = 10.0f;
    public float sensitivity = 30.0f;
    CharacterController character;
    public GameObject cam1; // Reference to Camera 1
    public GameObject cam2; // Reference to Camera 2
    public AudioListener audio1;
    public AudioListener audio2;

    float rotX, rotY;
    public bool webGLRightClickRotation = true;
    float gravity = -9.8f;
    Animator anim1; // Reference to the Animator component
    Animator animator;
    bool useCamera1 = true; // Flag to switch between cameras
    public float jumpForce = 10.0f;
 

    void Start()
    {
        //enable cameras and listeners at the start, default to camera1
        cam1.SetActive(useCamera1);
        cam2.SetActive(!useCamera1);
        audio1.enabled = useCamera1;
        audio2.enabled = !useCamera1;

        character = GetComponent<CharacterController>();
        if (Application.isEditor)
        {
            webGLRightClickRotation = false;
            sensitivity = sensitivity * 1.5f;
        }

        // Get a reference to the Animator component on the same GameObject
        anim1 = GetComponent<Animator>();
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        // Calculate movement direction based on input
        float moveFB = Input.GetAxis("Vertical") * speed;
        float moveLR = Input.GetAxis("Horizontal") * speed;

        Vector3 movement = new Vector3(moveLR, gravity, moveFB);

        if (webGLRightClickRotation)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                CameraRotation(cam1, rotX, rotY);
                
            }
        }
        else if (!webGLRightClickRotation)
        {
            CameraRotation(cam1, rotX, rotY);
            
        }

        // Handle jumping
        if (character.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // Apply the jump force
            movement.y = jumpForce;
            animator.SetTrigger("Jump"); // Set the "Jump" trigger in the Animator
            Debug.Log("Grounded: " + character.isGrounded);
        }

        // Handle running
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetTrigger("Run"); // Set the "Run" trigger in the Animator
            animator.ResetTrigger("Idle");
        }
        else
        {
            animator.ResetTrigger("Run"); // Reset the "Run" trigger when not moving
            animator.SetTrigger("Idle");
        }

        // Handle biting
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            animator.SetTrigger("Bite"); // Set the "Bite" trigger in the Animator
        }

        movement = transform.rotation * movement;
        character.Move(movement * Time.deltaTime);

        // Switch cameras when the "C" key is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            useCamera1 = !useCamera1;
            cam1.SetActive(useCamera1);
            cam2.SetActive(!useCamera1);
            audio1.enabled = useCamera1;
            audio2.enabled = !useCamera1;
       
        }
    }

    void CameraRotation(GameObject cam, float rotX, float rotY)
    {
        transform.Rotate(0, rotX * Time.deltaTime, 0);
        cam.transform.Rotate(-rotY * Time.deltaTime, 0, 0);
    }
    
}