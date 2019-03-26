using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningScreen : MonoBehaviour
{
    public GameObject background;
    public GameObject WinningCamera;
    public GameObject Old_Camera;
    public GameObject HUD;
    public GameObject NewHud;

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameFinish();
        }
    }

    public void GameFinish()
    {
        background.SetActive(true);
        WinningCamera.SetActive(true);
        Old_Camera.SetActive(false);
        HUD.SetActive(false);
        NewHud.SetActive(true);
        
    }
}
