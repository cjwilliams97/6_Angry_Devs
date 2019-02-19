using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float millisecondCounter;
    private float secondCounter;
    private float minuteCounter;
    string minutesString = "";
    string secondsString = "";
    string millisecondsString = "";
    private bool finished = false;
    public bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        finished = false;
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(finished)
        {
            return;
        }

        if (!paused)
        {
            secondCounter += Time.deltaTime;

            timerText.text = minuteCounter.ToString("00") + ":" + (secondCounter).ToString("00.00");

            if(secondCounter >= 60)
            {
                minuteCounter++;
                secondCounter = 0;
            }         
        }
    }

    public void Finish()
    {
        finished = true;
        timerText.color = Color.yellow; 
    }

    public void PausedGame()
    {
        paused = true;
    }

    public void ResumedGame()
    {
        paused = false;
    }
}
