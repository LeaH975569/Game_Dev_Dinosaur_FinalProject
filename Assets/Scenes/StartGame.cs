using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button beginButton;
    public string SnowScene;

    // Start is called before the first frame update
    void Start()
    {        
        beginButton.onClick.AddListener(TaskOnClickBeg); // add the button
    }
    void TaskOnClickBeg()
    {
        Debug.Log("You have clicked Begin Button!");
        SceneManager.LoadScene(SnowScene);
    }
}
