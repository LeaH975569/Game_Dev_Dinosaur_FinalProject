using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class CountdownTimer : MonoBehaviour
{
    public Slider countdownSlider;
    public float countdownTime = 5.0f;  
    private float currentTime;
    public string DeathScene;

    void Start()
    {
        currentTime = countdownTime;
        countdownSlider.maxValue = countdownTime;
        countdownSlider.value = countdownTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            SceneManager.LoadScene(DeathScene);
        }

        countdownSlider.value = currentTime;
    }
}
