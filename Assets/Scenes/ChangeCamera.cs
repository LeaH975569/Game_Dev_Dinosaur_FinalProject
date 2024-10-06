using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeCamera : MonoBehaviour
{
    public Camera Cam1;
    public Camera Cam2;
    public AudioListener a1;
    public AudioListener a2;

    // Start is called before the first frame update
    void Start()
    {
        Cam1.enabled = true;
        Cam2.enabled = false;
        a1.enabled = true;
        a2.enabled = false;

    }
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCameras();
        }
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
