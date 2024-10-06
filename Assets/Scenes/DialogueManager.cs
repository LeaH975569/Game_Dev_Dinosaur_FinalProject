using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject elderTextPanel;
    public TextMeshProUGUI talkText;
    public TextMeshProUGUI elderText;
    public Button talkButton;
    public Button closeButton;
    private bool isDialogActive = false;
    public string HuntScene;


    void Start()
    {
        // Ensure the elderTextPanel is initially hidden
        elderTextPanel.SetActive(false);

        // Add an onClick listener to the "talk" button
        talkButton.onClick.AddListener(StartDialog);

        // Add an onClick listener to the "close" button
        closeButton.onClick.AddListener(EndDialog);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HuntPortal"))
        {
            Debug.Log("Enter HuntPortal");
            SceneManager.LoadScene("HuntScene");
        }
    }

    void StartDialog()
    {
        isDialogActive = true;
        Time.timeScale = 0; // Pause the game
        talkText.gameObject.SetActive(false); // Hide the "talkText"
        elderTextPanel.SetActive(true); // Show the elderText panel
    }

    void EndDialog()
    {
        isDialogActive = false;
        Time.timeScale = 1; // Resume the game
        talkText.gameObject.SetActive(true); // Show the "talkText"
        elderTextPanel.SetActive(false); // Hide the elderText panel     
    }
}