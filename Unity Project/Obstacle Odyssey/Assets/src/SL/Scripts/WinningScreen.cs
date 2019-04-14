
/* This changes the cameras and activates objects on reaching the objective */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinningScreen : MonoBehaviour
{
    public GameObject background;   // The background of the winning screen
    public GameObject WinningCamera; // The new camera set to the above background
    public GameObject Old_Camera;   // The original Camera to be set unactive on win
    public GameObject HUD;          // The old HUD (Timers/etc) to be set unactive on win
    public GameObject NewHud;       // The new HUD (List of time/player etc)
    public Text NewTime;            // The time it took for the player to win
    public static bool IsFinished = false;  //flag for winning gamestate
    private KeyCode Escape = KeyCode.Escape;

    private void Awake()
    {
        IsFinished = false;
    }
    /* Checks for Input if flag is true */
    void Update()
    {
        if (Input.GetKey(Escape))
        {
            if( IsFinished == true)
            {
                SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
            }
        }
    }
    /* Moves Camera to ending area, gets ending time, displays score etc */
    public void GameFinish()
    {
        background.SetActive(true);
        WinningCamera.SetActive(true);
        Old_Camera.SetActive(false);
        HUD.SetActive(false);
        NewHud.SetActive(true);
        NewTime.text = Timer.Instance.GetTime(); // calls method through singleton implementation
        IsFinished = true;
        
    }
}
