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
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        Debug.Log("Loading");
    }
    void Exit_Clicked()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

    }
}