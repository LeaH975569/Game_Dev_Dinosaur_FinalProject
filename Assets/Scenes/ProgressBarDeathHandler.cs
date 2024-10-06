using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ProgressBarDeathHandler : MonoBehaviour
{
    public PlayerData playerdata;
    public Slider humanSlider;
    public Slider timeSlider;
    public TextMeshProUGUI humanValueText;  
    public TextMeshProUGUI timeValueText;

    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {        

        if (playerdata != null)
        {
            humanSlider.value = playerdata.humans;
            timeSlider.value = playerdata.countdownTime;

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

