/*This script contains the Singelton pattern, which limits the amount of classes that exsits
 * to one. It also contains code for a timer, and is used for the JMStressTest scene.
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Singelton : MonoBehaviour
{
    //Implementing singleton patter, which makes sure only one of these classes exsits

    public static Singelton Instance { get; private set; }

    //Awake is called only once during the lifetime of the script instance. 
    //And is called after all objects are initialized so you can safely speak to other objects
    private void Awake()
    {
        if (Instance == null) // No instance has yet been made
        {
            Instance = this; // This is the first instance
            DontDestroyOnLoad(gameObject);
        }

        else // Get rid of all extras
        {
            Destroy(gameObject);
        }
    }

    //Declarations
    public Text timerText;   //Used to show the time
    public float timertime = Time.time; // Initialize the timer

    void Start()
    {
        //Initialize Timer Text
        timerText.text = "JM Test: " + timertime.ToString();
    }

    void Update()
    {
        //Update Timer to show time passed 
        timertime = Time.time;
        timerText.text = "JM Test: " + timertime.ToString();
    }
}
