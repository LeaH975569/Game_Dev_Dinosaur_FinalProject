using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Camera Cam1;
    public Camera Cam2;
    public AudioListener a1;
    public AudioListener a2;
    public GameObject player;

    public float rotationSpeed = 2.0f; // Speed of camera rotation

    private Vector3 offset;

    private float rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cam1.enabled = true;
        Cam2.enabled = false;
        a1.enabled = true;
        a2.enabled = false;
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCameras();
        }

        // Get mouse input for camera rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the player and camera based on mouse input
        player.transform.Rotate(Vector3.up * mouseX * rotationSpeed);
        rotationX += mouseY * rotationSpeed;  
        rotationX = Mathf.Clamp(rotationX, -90, 90); // Clamp vertical rotation to prevent flipping

        // Apply rotation to the camera
        transform.rotation = Quaternion.Euler(-rotationX, player.transform.rotation.eulerAngles.y, 0);

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }

    void ToggleCameras()
    {
        if (Cam1.enabled)
        {
            Cam1.enabled = false;
            Cam2.enabled = true;
            a1.enabled = false;
            a2.enabled = true;
        }
        else
        {
            Cam1.enabled = true;
            Cam2.enabled = false;
            a1.enabled = true;
            a2.enabled = false;
        }
    }
}