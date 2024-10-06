using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharController_Motor : MonoBehaviour
{

    public float speed = 10.0f;
    public float sensitivity = 30.0f;
    public float JumpSpeed = 1000.0f;
    public float WaterHeight = 15.5f;
    CharacterController character;
    public GameObject cam;
    float moveFB, moveLR;
    float rotX, rotY;
    public bool webGLRightClickRotation = true;
    float gravity = -9.8f;
    private Animator animator;





    void Start()
    {
        //LockCursor ();
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        if (Application.isEditor)
        {
            webGLRightClickRotation = false;
            sensitivity = sensitivity * 1.5f;
        }

    }



    void CheckForWaterHeight()
    {
        if (transform.position.y < WaterHeight)
        {
            gravity = 0f;
        }
        else
        {
            gravity = -9.8f;
        }
    }



    void Update()
    {

        moveFB = Input.GetAxis("Horizontal") * speed;
        moveLR = Input.GetAxis("Vertical") * speed;
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        CheckForWaterHeight();

        Vector3 movement = new Vector3(moveFB, gravity, moveLR);

        if (webGLRightClickRotation)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                CameraRotation(cam, rotX, rotY);
            }
        }
        else if (!webGLRightClickRotation)
        {
            CameraRotation(cam, rotX, rotY);
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Bite"); // Trigger "Bite" animation
        }

        // Check for other key inputs
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            {
                animator.SetTrigger("Jump"); // Trigger "Jump" animation only if not already jumping
            }
            else
            {
                // Add vertical movement while the jump animation is playing
                movement.y += JumpSpeed; // Adjust JumpSpeed to control the height of the jump
            }
        }

        // Check for movement keys
        float moveSpeed = Mathf.Sqrt(moveFB * moveFB + moveLR * moveLR);

        // Check for specific movement keys to trigger "Run" animation
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Run", true); // Set "Run" animation to true
        }
        else
        {
            animator.SetBool("Run", false); // Set "Run" animation to false
        }

        movement = transform.rotation * movement;
        character.Move(movement * Time.deltaTime);
    }


    void CameraRotation(GameObject cam, float rotX, float rotY)
    {
        transform.Rotate(0, rotX * Time.deltaTime, 0);
        cam.transform.Rotate(-rotY * Time.deltaTime, 0, 0);
    }




}
