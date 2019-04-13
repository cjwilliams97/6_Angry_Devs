/* Disables or enables the Pause Menu depending on method called from PlayerPause.cs */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvasControl : MonoBehaviour
{
    public GameObject Menu; //The object that is the canvas of the pause menu

    /* Deactivates the Menu */
    public void DisablePauseCanvas()    
    {
        Menu.SetActive(false);
        
    }
    /* ReActivates the Menu */
    public void EnablePauseCanvas()
    {
        Menu.SetActive(true);
    }
}
