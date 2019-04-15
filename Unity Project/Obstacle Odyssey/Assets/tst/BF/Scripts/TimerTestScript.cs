/* Brandon Foss
 * This script will run a stress test for the timer that will ensure
 * that the timer ends when making contact with the ending chest
 * and that it doesn't display more than the boundaries of the hud display
 * at high numbers
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // allows text manipulation
using UnityEngine.SceneManagement;

public class TimerTestScript : MonoBehaviour
{
    public Text timerText; // creates the Text object which is attached to the timer text in the HUD canvas
    public Text test2Text;
    public Text test3Text;
    private float centisecondCounter = 0f; // creates/initializes a centisecond counter (1/100th of a second)
    private float secondCounter = 0f; // creates/initializes a second counter
    private float minuteCounter = 0f; // creates/initializes a minute counter
    private string centisecondString = ""; // creates/initializes a string to print centiseconds
    private string secondString = ""; // creates/initializes a string to print seconds
    private string minuteString = ""; // creates/initializes a string to print minutes
    private bool finished1 = false;
    private bool finished2 = false;
    public bool paused = false;
    private bool flag = false;
    private bool flag2 = false;
    private bool flag3 = false;
    private bool flag4 = false;
    //private bool passed2 = false;
    //private bool passed3 = false;
    private float countdown = 4;
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "00:00:00"; // starts clock display at 00 for all values
        finished1 = false; // ensures finished starts as false
        finished2 = false;
        paused = false; // ensures paused starts as false
        flag = false; // ensures flag starts as false
        flag2 = false;
        //passed2 = false;
        //passed3 = false;
        test2Text.text = "Test 2 - Timer Stops at High Values - Pending";
        test3Text.text = "Test 3 - Timer Stops When Chest Hit - Pending";
        countdown = 4;
        coroutine = WaitAndChangeScene(5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(flag2)
        {
            finished1 = false;
            countdown -= Time.deltaTime;
            if (countdown < 1)
            {
                minuteCounter = 93;
                centisecondCounter = 0;
                secondCounter = 0;
                paused = false;
                timerText.color = Color.blue;
                flag3 = true;
                flag2 = false;
            }
        }

        // if the finished variable is set to true, then update stops running
        if(finished1)
        {
            if(!flag2 && !flag3)
            {
                flag2 = true;
            }

            //return;
            paused = true;
        }

        if (finished2)
        {
            if (flag == true) // This stops timer and displays message if minutes exceed 99
            {
                timerText.fontSize = 25;
                timerText.color = Color.red;
                timerText.text = "You Took Too Long!!";
                test2Text.color = Color.green;
                //passed2 = true;
                test2Text.text = "Test 2 - Timer Stops at High Values - Passed";
                if(flag4 == false)
                {
                    StartCoroutine(coroutine);
                    flag4 = true;
                }
            }

            return;
            //paused = true;
        }

        // when paused isn't true, update time
        if (!paused)
        {
            // tracks time in seconds for frames to complete. Multiplied by 100 to find centisecond
            // this keeps time consistent throughout the game regardless of fps
            //centisecondCounter += Time.deltaTime * 100; 

            centisecondCounter += Time.deltaTime * 10000; // this can be enabled to test time increments at a faster rate
                                                          //centisecondCounter += Time.deltaTime * 8; // this can be enabled to test time increments at slower rate

            if (flag)
            {
                if(secondCounter == 58)
                finished2 = true;
            }

            // this checks if centisecond hits 100 so it can increment other values
            if (centisecondCounter >= 99)
            {
                // it then checks where the second counter is at to see if minutes needs to update first
                if (secondCounter >= 59)
                {
                    if (minuteCounter == 98) // This checks if minute is about to wrap too high
                    {
                        flag = true;
                    }

                    minuteCounter++; // instead of seconds hitting 60, the minute field is updated

                    secondCounter = 0; // then the seconds field resets
                }

                // this ensures that seconds is less than 60 first
                // it is implied from the above check, but it is a good double check to make sure things are running properly
                else if (secondCounter < 59)
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
        finished1 = true; // sets the game finished to true
        timerText.color = Color.red;  // sets the time display to red to indicate a finishing time
        test3Text.color = Color.green;
        //passed3 = true;
        //flag2 = true;
        test3Text.text = "Test 3 - Timer Stops When Chest Hit - Passed";
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

    private IEnumerator WaitAndChangeScene(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Returned from wait time");
        SceneManager.LoadScene("BrandonStatePatternTest", LoadSceneMode.Single);
    }
}
