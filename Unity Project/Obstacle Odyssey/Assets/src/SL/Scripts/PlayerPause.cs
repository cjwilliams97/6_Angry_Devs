
/* Edits Things the Player Sees on pause initiation
 * Detects the input that starts the pause process */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPause : MonoBehaviour
{
    private KeyCode Escape = KeyCode.Escape;    //The Keycode that will activate pause Menu (Should be "ESC"
    private GameObject Menu;                    
    public bool Paused = false;                 // THe flag for if the game is currently paused
    void Start()
    {
        Menu = GameObject.Find("PauseMenu");
        GetComponent<PauseCanvasControl>().DisablePauseCanvas();    //Makes sure the Pause is disabled on start
      
    }
    /* Checks for User Input at end of Every Frame */
    void LateUpdate()
    {
        /* Checks to make sure it isnt in a win conditon or lose condition */
        /* Toggles between open/closed depending on current Paused Flag */
        if (Input.GetKeyDown(Escape) && WinningScreen.IsFinished == false && LoseCondition.IsFailed == false)
        {
            if (Paused == false)
            {
                OpenPause();
                
            }
            else if(Paused == true)
            {
                ClosePause();
            }
        }
    }
    /* Sets Paused Flag true, Stops Timer/Physics Time, Calls to PauseCanvasControl to enable the object */
    public void OpenPause()
    {
        Paused = true;
        Timer.Instance.PausedGame(); // calls method through singleton implementation
        Time.timeScale = 0.0f;
        Debug.Log("Escape Initiated");
        GetComponent<PauseCanvasControl>().EnablePauseCanvas();
    }
    /* Sets Paused Flag false, Resumes Timer/Physics Time, Calls to PauseCanvasControl to disable object */
    public void ClosePause()
    {
        Paused = false;
        Timer.Instance.ResumedGame(); // calls method through singleton implementation
        Time.timeScale = 1.0f;
        Debug.Log("Escape Closed");
        GetComponent<PauseCanvasControl>().DisablePauseCanvas();
    }
}
