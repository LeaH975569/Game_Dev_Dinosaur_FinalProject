using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    public PlayerData playerdata;
    public Slider progressbar;
    public Slider countdownSlider;

    public TextMeshProUGUI humanValueText;
    public TextMeshProUGUI timeValueText;

    // Create separate fields for minutes and seconds
    public int countdownMinutes = 1; // Default to 1 minute
    public int countdownSeconds = 30; // Default to 30 seconds

    // Calculate the countdown time in seconds
    private float countdownTime;

    private float currentTime;
    public string DeathScene;
    public string FeastScene;
    public string HuntScene;

    // Start is called before the first frame update
    void Start()
    {
        playerdata.humans = 0;

        // Calculate the initial countdown time in seconds
        countdownTime = countdownMinutes * 60 + countdownSeconds;

        currentTime = countdownTime;
        countdownSlider.maxValue = countdownTime;
        countdownSlider.value = countdownTime;
    }



    public void UpdateHumanScore()
    {
        progressbar.value = playerdata.humans;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHumanScore();

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            Debug.Log("Load DeathScene");
            SceneManager.LoadScene(DeathScene);
        }

        countdownSlider.value = currentTime;
        playerdata.countdownTime = currentTime;

        if (playerdata != null)
        {
            progressbar.value = playerdata.humans;
            countdownSlider.value = playerdata.countdownTime;

            if (humanValueText != null)
            {
                humanValueText.text = playerdata.humans + " / 10 Captured Humans";
            }

            if (timeValueText != null)
            {
                timeValueText.text = Mathf.Floor(playerdata.countdownTime) + " Sec left";
            }
        }

    }

}
