using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuControl : MonoBehaviour
{
    public Button Resume_btn, Setting_Btn, Exit_btn;

    void Start()
    {
        Resume_btn.onClick.AddListener(Resume_Clicked);
        Exit_btn.onClick.AddListener(Exit_Clicked);
    }

    void Resume_Clicked()
    {
        
    }
    void Exit_Clicked()
    {
        Debug.Log("Loading MainMenu");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

    }
}