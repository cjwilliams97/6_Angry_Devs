using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
using UnityEngine.SceneManagement;

//---------Place next scene to be loaded in the function named "DisplayStats()"-------------------//

public class AcceptanceTest : MonoBehaviour
{
    static bool TestStatus = true; //When test fails, TestStatus == false, while passing == true.
    static bool InCountdown = false; //Checks to see if in 5 second countdown, from when FPS drops below 15
    static bool TestFinished = false; //Keeps track if the test has finished
    public Text display_text; //Display text on HUD
    public Text display_text_2;
    static int NumBarrelsAtFailure = 0;
    
    

    // Start is called before the first frame update

    void Start()
    {
        TestStatus = true;
        TestFinished = false;
        InCountdown = false;
        

    }

    // Update is called once per frame
    void Update()
    {
      
        if(FPS_Counter.avgFrameRate < 15) //if FPS is < 15
        {
            if (InCountdown == false) //if not already in a countdown...
            {
                StartCoroutine("StartTimer");
            }
            //TestStatus = false;
        }
        else
        {
            InCountdown = false;
        }

        // Displays test status on HUD.
        if (TestStatus == true)
        {
            display_text.text = "Test Status: Passing";
        }
        else
        {
            display_text.text = "Test Status: Failed";
            if (!TestFinished)
            {
                
                TestFinished = true;
                StartCoroutine("DisplayStats");


            }
        }
        
    }

    IEnumerator StartTimer()
    {
        InCountdown = true;
        yield return new WaitForSeconds(3f);
        if (InCountdown)
        {
            NumBarrelsAtFailure = BarrelManager.barrel_count;
            TestStatus = false;
            InCountdown = false;
        }
    }
    IEnumerator DisplayStats()
    {
        display_text_2.text = string.Concat("Barrel Count at Failure: ", NumBarrelsAtFailure.ToString());
        yield return new WaitForSeconds(5f);
        
        //-------------------------LOAD NEXT SCENE HERE------------------------------------//
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
