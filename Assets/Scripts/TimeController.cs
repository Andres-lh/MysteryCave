using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [Header("Timer Setup")]
    [SerializeField] private TextMeshProUGUI timerDisplay;
    [SerializeField] private TextMeshProUGUI loopText;
    [SerializeField] private float timeInSeconds;

    private float currentTime;
    private int timeLoop = 0;
    public bool shouldCountDown = true;
    
    private void Start()
    {
        currentTime = timeInSeconds;
    }

    void Update()
    {
        Timer();
    }

    private void Timer()
    {

        if(currentTime >= 0 && shouldCountDown) currentTime -= Time.deltaTime;

        if (currentTime <= 0 && shouldCountDown) 
        {
            shouldCountDown = false;
            currentTime = 0;
            timerDisplay.color = Color.red;
            
            StartCoroutine(RestartCountDown());
        }

        timerDisplay.text = currentTime.ToString("0.0");
    }
    
    private IEnumerator RestartCountDown()
    {
        timeLoop += 1;
        yield return new WaitForSeconds(2);
        currentTime = timeInSeconds;
        loopText.text = $"Time loop: {timeLoop}";
        timerDisplay.color = Color.white;
        shouldCountDown = true;
    }
}
