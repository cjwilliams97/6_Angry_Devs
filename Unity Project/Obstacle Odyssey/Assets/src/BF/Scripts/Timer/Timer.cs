/* Brandon Foss
 * This script runs the timer hud display to count upwards
 * showing centiseconds, seconds, and minutes on the hud. Other scripts
 * call it when the game is paused or unpaused. It is also used to retreive the time
 * for winning menu displays.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // allows text manipulation

public class Timer : MonoBehaviour
{
    // the following 16 lines act as a singleton pattern to ensure that there is only 1 instance of this class
    public static Timer Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) // if nothing is stored in Instance property
        {
            Instance = this; // set to contain this particular instance
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject); // otherwise destroys duplicate instances and gameObjects
        }
    }

    public Text timerText; // creates the Text object which is attached to the timer text in the HUD canvas
    private float centisecondCounter = 0f; // creates/initializes a centisecond counter (1/100th of a second)
    private float secondCounter = 0f; // creates/initializes a second counter
    private float minuteCounter = 0f; // creates/initializes a minute counter
    private string centisecondString = ""; // creates/initializes a string to print centiseconds
    private string secondString = ""; // creates/initializes a string to print seconds
    private string minuteString = ""; // creates/initializes a string to print minutes
    private bool finished = false;
    public bool paused = false;
    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "00:00:00"; // starts clock display at 00 for all values
        finished = false; // ensures finished starts as false
        paused = false; // ensures paused starts as false
        flag = false; // ensures flag starts as false
    }

    // Update is called once per frame
    void Update()
    {
        // if the finished variable is set to true, then update stops running
        if (finished) 
        {
            if(flag == true) // This stops timer and displays message if minutes exceed 99
            {
                timerText.fontSize = 25;
                timerText.color = Color.red;
                timerText.text = "You Took Too Long!!";
            }

            return;
        }

        // when paused isn't true, update time
        if (!paused)
        {
            // tracks time in seconds for frames to complete. Multiplied by 100 to find centisecond
            // this keeps time consistent throughout the game regardless of fps
            centisecondCounter += Time.deltaTime * 100; 

            //centisecondCounter += Time.deltaTime * 80000; // this can be enabled to test time increments at a faster rate
            //centisecondCounter += Time.deltaTime * 8; // this can be enabled to test time increments at slower rate

            // this checks if centisecond hits 100 so it can increment other values
            if (centisecondCounter >= 99)
            {
                // it then checks where the second counter is at to see if minutes needs to update first
                if(secondCounter >= 59)
                {
                    minuteCounter++; // instead of seconds hitting 60, the minute field is updated

                    if(minuteCounter == 99) // This checks if minute is about to wrap too high
                    {
                        if(secondCounter == 59)
                        {
                            flag = true;
                            finished = true;
                        }
                    }

                    secondCounter = 0; // then the seconds field resets
                }

                // this ensures that seconds is less than 60 first
                // it is implied from the above check, but it is a good double check to make sure things are running properly
                else if(secondCounter < 59)
                {
                    secondCounter++; // will increment the second
                }

                centisecondCounter = 0; // then centisecond is reset to 0 so that it restarts instead of hitting 101
            }

            // the following checks ensure that the time displayed looks clean and consistent

            // if the minutes field is less than 0, then fill in a 0 at the beginning to ensure 2 numbers are displayed
            if (minuteCounter < 10)
            {
                minuteString = "0" + minuteCounter;
            }

            else
            {
                minuteString = "" + minuteCounter;
            }

            // if the seconds field is less than 0, then fill in a 0 at the beginning to ensure 2 numbers are displayed
            if (secondCounter < 10)
            {
                secondString = "0" + secondCounter;
            }

            else
            {
                secondString = "" + secondCounter;
            }

            // if the centiseconds field is less than 0, then fill in a 0 at the beginning to ensure 2 numbers are displayed
            if ((int)centisecondCounter < 10)
            {
                centisecondString = "0" + (int)centisecondCounter;
            }

            else
            {
                centisecondString = "" + (int)centisecondCounter;
            }

            // this will actually update the text field and display where my timer text is set up in the HUD canvas
            timerText.text = minuteString + ":" + secondString + ":" + centisecondString;
        }
    }

    // this is called if the boat hits the treasure chest
    public void GameFinish()
    {
        finished = true; // sets the game finished to true
        timerText.color = Color.red;  // sets the time display to red to indicate a finishing time
    }

    // this is called with the pause menu to pause the incrementing of time
    public void PausedGame()
    {
        paused = true; // sets paused to true
    }

    // this is called when leaving a pause menu to resume incrementing of time
    public void ResumedGame()
    {
        paused = false; // sets paused to false
    }

    // this will allow someone to retrieve the current time
    public string GetTime()
    {
        return minuteString + ":" + secondString + ":" + centisecondString;
    }
}
