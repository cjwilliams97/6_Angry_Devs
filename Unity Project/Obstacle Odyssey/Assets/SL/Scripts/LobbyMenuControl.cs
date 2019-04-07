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
        //Time.fixedDeltaTime = 1.0f;
        //Time.timeScale = 1.0f;
    }

    void Update()
    {
        
        DesiredMap = GameObject.Find("Dropdown").GetComponent<DropDownHandler>().RequestMap();
    }
    void Play_Clicked()
    {
        Debug.Log("Loading");
        SceneManager.LoadScene(DesiredMap, LoadSceneMode.Single);
        
    }
    void Perks_Clicked()
    {
        Debug.Log("Loading Perks");
        SceneManager.LoadScene("Perks", LoadSceneMode.Single);
    }
    void Exit_Clicked()
    {
        Debug.Log("Loading Main Menu");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        

    }
}