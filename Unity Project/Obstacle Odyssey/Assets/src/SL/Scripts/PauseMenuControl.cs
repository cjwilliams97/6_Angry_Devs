
/* The pause Menu Interface control/Handler */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuControl : MonoBehaviour
{
    public Button Resume_btn, Reset_btn, Exit_btn;
   
    public GameObject Reference; // The Gameobject where PlayerPause is assigned

    void Start()
    {
        
        Resume_btn.onClick.AddListener(Resume_Clicked);
        Reset_btn.onClick.AddListener(Restart_Clicked);
        Exit_btn.onClick.AddListener(Exit_Clicked);
    }
    /* When Resume Button is clicked */
    void Resume_Clicked()
    {
       Reference.GetComponent<PlayerPause>().ClosePause();
    }
    /* When Restart is Clicked STILL A WIP */
    void Restart_Clicked()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /* Restarts Time, Loads the Lobby Scene */
    void Exit_Clicked()
    {
        Time.timeScale = 1.0f;
        //Debug.Log("Loading MainMenu");
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);

    }
}