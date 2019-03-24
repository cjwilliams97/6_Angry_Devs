using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPause : MonoBehaviour
{
    private KeyCode Escape = KeyCode.Escape;
    public Rigidbody rigid;
    private GameObject Menu;
    public bool Paused = false;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Menu = GameObject.Find("PauseMenu");
        rigid.GetComponent<PauseCanvasControl>().DisablePauseCanvas();
      
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(Escape))
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
        rigid.GetComponent<Timer>().PausedGame();
        Time.timeScale = 0.0f;
        Debug.Log("Escape Initiated");
        rigid.GetComponent<PauseCanvasControl>().EnablePauseCanvas();
    }
    public void ClosePause()
    {
        Paused = false;
        rigid.GetComponent<Timer>().ResumedGame();
        Time.timeScale = 1.0f;
        Debug.Log("Escape Closed");
        rigid.GetComponent<PauseCanvasControl>().DisablePauseCanvas();
    }
}
