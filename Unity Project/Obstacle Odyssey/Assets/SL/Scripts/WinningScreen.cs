using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinningScreen : MonoBehaviour
{
    public GameObject background;
    public GameObject WinningCamera;
    public GameObject Old_Camera;
    public GameObject HUD;
    public GameObject NewHud;
    public Text NewTime;
    public bool IsFinished = false;
    private KeyCode Escape = KeyCode.Escape;

    private void Awake()
    {
        IsFinished = false;
    }

    void Update()
    {
        if (Input.GetKey(Escape))
        {
            if( IsFinished == true)
            {
                SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
            }
        }
    }
    public void GameFinish()
    {
        background.SetActive(true);
        WinningCamera.SetActive(true);
        Old_Camera.SetActive(false);
        HUD.SetActive(false);
        NewHud.SetActive(true);
        NewTime.text = GetComponent<Timer>().GetTime();
        IsFinished = true;
        
    }
}
