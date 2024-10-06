using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HumanCapture : MonoBehaviour
{
    public GameObject playername;
    public PlayerData playerdata;
    public string FeastScene;


    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            // Increase the count of captured humans.
            playerdata.humans += 1;

            // Make the human GameObject disappear.
            other.gameObject.SetActive(false);
            Debug.Log("Human captured from Human Capture Script");
        }

        if (other.CompareTag("FeastPortal"))
        {
            Debug.Log("FeastPortal Triggered");

            if (playerdata.humans > 9)
            {
                Debug.Log("Feast Scene Loaded");
                SceneManager.LoadScene("FeastScene");
            }
        }

    }


    void Update()
    {
        
    }
}
