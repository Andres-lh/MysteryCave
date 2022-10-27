using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [Header("Timer Setup")]
    [SerializeField] private TextMeshProUGUI timerDisplay;
    [SerializeField] private float timeInSeconds;
    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    private void Timer()
    {
        timeInSeconds -= Time.deltaTime;

        if (timeInSeconds <= 0)
        {
            timeInSeconds = 0;
            timerDisplay.color = Color.red;
        }

        timerDisplay.text = timeInSeconds.ToString("0.0");
    } 

}
