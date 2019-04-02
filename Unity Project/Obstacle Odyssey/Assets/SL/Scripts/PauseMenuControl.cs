using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuControl : MonoBehaviour
{
    public Button Resume_btn, Reset_btn, Exit_btn;
    public GameObject Menu;

    void Start()
    {
        
        Resume_btn.onClick.AddListener(Resume_Clicked);
        Reset_btn.onClick.AddListener(Restart_Clicked);
        Exit_btn.onClick.AddListener(Exit_Clicked);
    }

    void Resume_Clicked()
    {
       // rigid.GetComponent<PlayerPause>().ClosePause();
    }
    void Restart_Clicked()
    {
        //SceneManager.LoadScene("GameScene",LoadSceneMode.Single);
    }
    void Exit_Clicked()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Loading MainMenu");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

    }
}