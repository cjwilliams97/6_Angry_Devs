using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

//---------Place next scene to be loaded in the function named "DisplayStats()"-------------------//

public class AcceptanceTest : MonoBehaviour
{
    static bool TestStatus = true; //When test fails, TestStatus == false, while passing == true.
    static bool InCountdown = false; //Checks to see if in 5 second countdown, from when FPS drops below 15
    static bool TestFinished = false; //Keeps track if the test has finished
    public Text display_text; //Display text on HUD
    public Text display_text_2;
    public Text TestText;
    private static System.Timers.Timer aTimer;
    private static System.Timers.Timer StatsTimer;
    private static int time_delay = 3000; //time delay before declaring test a failure at < 15 FPS
    static int NumBarrelsAtFailure = 0;
    
    

    // Start is called before the first frame update

    void Start()
    {
        TestStatus = true;
        TestFinished = false;
        InCountdown = false;
        //time_delay = 3000;
       // stats_delay = 500;
        

    }

    // Update is called once per frame
    void Update()
    {
      
        if(FPS_Counter.avgFrameRate < 15) //if FPS is < 15
        {
            if (InCountdown == false) //if not already in a countdown...
            {
                SetTimer(); //Start a timer for 5 seconds
                InCountdown = true;
            }
            //TestStatus = false;
        }
        else
        {
            if (InCountdown == true)
            {
                aTimer.Stop();
                aTimer.Dispose();
            }
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

    private void SetTimer()
    {
        aTimer = new System.Timers.Timer();
        aTimer.Interval = time_delay;
        aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimeExpired);
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }
    private void OnTimeExpired(object sender, ElapsedEventArgs e)
    {
        NumBarrelsAtFailure = BarrelManager.barrel_count;
        TestStatus = false;
    }
    IEnumerator DisplayStats()
    {
        display_text_2.text = string.Concat("Barrel Count at Failure: ", NumBarrelsAtFailure.ToString());
        yield return new WaitForSeconds(5f);
        
        //-------------------------LOAD NEXT SCENE HERE------------------------------------//
    }

}
