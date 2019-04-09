
/* Containts the Listeners, and scene changer for the Lobby Scene */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyMenuControl : MonoBehaviour
{
    public Button Play_btn, Exit_btn ,Perks_btn;
    public Dropdown drop;
    public string DesiredMap;
    void Start()
    {
        drop = GetComponent<Dropdown>();
        Play_btn.onClick.AddListener(Play_Clicked);
        Exit_btn.onClick.AddListener(Exit_Clicked);
        Perks_btn.onClick.AddListener(Perks_Clicked);
    }

    /* Constnantly Updates the Dropdown menu to the selected map every frame */
    void Update()
    {
        DesiredMap = GameObject.Find("Dropdown").GetComponent<DropDownHandler>().RequestMap();
    }
    /* Loads the Chosen Map On clicking the play button */
    void Play_Clicked()
    {
        //Debug.Log("Loading");
        SceneManager.LoadScene(DesiredMap, LoadSceneMode.Single); 
    }
    /* Loads the Perks Scene When Customization button is clicked */
    void Perks_Clicked()
    {
        //Debug.Log("Loading Perks");
        SceneManager.LoadScene("Perks", LoadSceneMode.Single);
    }
    /* Loads the Main Main Menu When exit is clicked in lobby */
    void Exit_Clicked()
    {
        //Debug.Log("Loading Main Menu");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}