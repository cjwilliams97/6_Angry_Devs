using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public Button Start_btn, Settings_btn, Exit_btn;

    void Start()
    {
        Start_btn.onClick.AddListener(Start_Clicked);
        Settings_btn.onClick.AddListener(Setting_Clicked);
        Exit_btn.onClick.AddListener(Exit_Clicked);
    }

    void Start_Clicked()
    {
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
    void Setting_Clicked()
    {

    }
    void Exit_Clicked()
    {
        Application.Quit();
    }
}