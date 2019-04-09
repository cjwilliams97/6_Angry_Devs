

/* This script controls all elements of the Main Menu, button controls etc. */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public Button Start_btn, Setting_Btn, Exit_btn, Test_btn;

    void Start()
    {
        Test_btn.onClick.AddListener(Test_Clicked);
        Start_btn.onClick.AddListener(Play_Clicked);
        Exit_btn.onClick.AddListener(Exit_Clicked);
    }
    /* Proceedes to the lobby scene if Start button i clicked from main menu */
    void Play_Clicked()
    {
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
    /* Exits the application if exit is clicked from main menu */
    void Exit_Clicked()
    {
        Application.Quit();

    }
    /* This button IF ENABLED, would start the Testing conditions */
    void Test_Clicked()
    {
        SceneManager.LoadScene("BrandonHudTest", LoadSceneMode.Single);
    }
}