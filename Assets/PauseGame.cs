using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseTheGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button pauseButton;
    public Button restartButton; // Reference to the restart button in the Unity Inspector
    private bool isPaused = false;


    private void Start()
    {
        // Ensure the pause menu is initially hidden
        pauseMenu.SetActive(false);

        // Add listeners to the buttons' click events
        pauseButton.onClick.AddListener(TogglePause);
        restartButton.onClick.AddListener(RestartGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                ExitGame();
            }
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        // Freeze time and show the pause menu
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (isPaused)
        {
            // Unfreeze time and hide the pause menu
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            isPaused = false;
        }
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // This exits Play mode in the Unity Editor
        #else
        Application.Quit(); // This quits the standalone build of the game
        #endif
    }

    public void RestartGame()
    {        
        SceneManager.LoadScene("SampleScene");  
    }
}