using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public Button Start_btn, Setting_Btn, Exit_btn;

    void Start()
    {
        Start_btn.onClick.AddListener(Play_Clicked);
        Exit_btn.onClick.AddListener(Exit_Clicked);
    }

    void Play_Clicked()
    {
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
        Debug.Log("Loading");
    }
    void Exit_Clicked()
    {
        Application.Quit();

    }
}