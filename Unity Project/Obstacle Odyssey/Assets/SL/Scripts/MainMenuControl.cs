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

    void Play_Clicked()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        //Debug.Log("Loading");
    }
    void Exit_Clicked()
    {
        Application.Quit();

    }
    void Test_Clicked()
    {
        SceneManager.LoadScene("SLFailedTest", LoadSceneMode.Single);
    }
}