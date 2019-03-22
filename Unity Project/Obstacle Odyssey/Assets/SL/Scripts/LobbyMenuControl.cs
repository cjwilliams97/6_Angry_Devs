using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyMenuControl : MonoBehaviour
{
    public Button Play_btn, Exit_btn;

    void Start()
    {
        Play_btn.onClick.AddListener(Play_Clicked);
        Exit_btn.onClick.AddListener(Exit_Clicked);
    }
    void Play_Clicked()
    {
        Debug.Log("Loading");
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        
    }
    void Exit_Clicked()
    {
        Debug.Log("Loading Main Menu");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        

    }
}