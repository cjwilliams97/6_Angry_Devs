

/* This script controls all elements of the Main Menu, button controls etc. */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public static MainMenuControl Instance { get; private set; }

    /* Singlton Pattern, only allows for one instance of MainMenu Gameobject */
    private void Awake()
    {
        if(Instance == null) //If class isnt instantiate
        {
            Instance = this;    //set Instance != NULL
            DontDestroyOnLoad(gameObject); //dont destroy the onbject on load
        }
        else
        {
            Destroy(gameObject); //gameobject already exits, destroy any new 
                                // gameobject
        }
    }
    public Button Start_btn, Setting_Btn, Exit_btn, Test_btn;

    void Start()
    {
        Test_btn.onClick.AddListener(Test_Clicked);
        Start_btn.onClick.AddListener(Play_Clicked);
        Exit_btn.onClick.AddListener(Exit_Clicked);
        
    }
    /* Proceedes to the lobby scene if Start button i clicked from main menu */
    /* This is where you will change the Scene Name of what you want to direct to,
     * "Lobby" is the current next scene in this scenario */
    void Play_Clicked()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
    /* Exits the application if exit is clicked from main menu */
    void Exit_Clicked()
    {
        Destroy(gameObject);
        Application.Quit();

    }
    /* This button IF ENABLED, would start the Testing conditions */
    void Test_Clicked()
    {
        //SceneManager.LoadScene("", LoadSceneMode.Single);
    }
}