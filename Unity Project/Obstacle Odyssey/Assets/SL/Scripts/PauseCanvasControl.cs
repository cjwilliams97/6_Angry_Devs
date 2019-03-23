using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvasControl : MonoBehaviour
{
    public GameObject Menu;

    public void DisablePauseCanvas()
    {
        Menu.SetActive(false);
        
    }
    public void EnablePauseCanvas()
    {
        Menu.SetActive(true);
    }
}
