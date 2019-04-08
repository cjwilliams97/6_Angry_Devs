using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPause : MonoBehaviour
{
    private KeyCode Escape = KeyCode.Escape;
    private GameObject Menu;
    public bool Paused = false;
    void Start()
    {
        Menu = GameObject.Find("PauseMenu");
        GetComponent<PauseCanvasControl>().DisablePauseCanvas();
      
    }

    void LateUpdate()
    {
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
    public void OpenPause()
    {
        Paused = true;
        GetComponent<Timer>().PausedGame();
        Time.timeScale = 0.0f;
        Debug.Log("Escape Initiated");
        GetComponent<PauseCanvasControl>().EnablePauseCanvas();
    }
    public void ClosePause()
    {
        Paused = false;
        GetComponent<Timer>().ResumedGame();
        Time.timeScale = 1.0f;
        Debug.Log("Escape Closed");
        GetComponent<PauseCanvasControl>().DisablePauseCanvas();
    }
}
