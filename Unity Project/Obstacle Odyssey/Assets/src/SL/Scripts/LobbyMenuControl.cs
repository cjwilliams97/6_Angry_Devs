/* 
 * Containts the Listeners, and scene changer for the Lobby Scene
 * Created by Sheldon Lockie
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyMenuControl : MonoBehaviour
{
    public static LobbyMenuControl Instance { get; private set; }

    /* Singlton Pattern, only allows for one instance of LobbyMenu Gameobject */
    private void Awake()
    {
        if (Instance == null) //If class isnt instantiate
        {
            Instance = this;    //set Instance != NULL
            DontDestroyOnLoad(gameObject); //dont destroy the onbject on load
        }
        else
        {
            Destroy(gameObject); //gameobject already exits, destroy any new 
                                 // gameobject
        }
    }
    public Button Play_btn, Exit_btn ,Perks_btn;
    public Dropdown drop;
    public string DesiredMap;
    public OdysseySceneLoader OdySceneLoader; // [connor's code] used in Play_Clicked()
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
        OdySceneLoader.DesiredMap = DesiredMap; // [connor's code]
        Destroy(gameObject);
        OdySceneLoader.LoadScene(); // [connor's code]
    }
    /* Loads the Perks Scene When Customization button is clicked */
    void Perks_Clicked()
    {
        //Debug.Log("Loading Perks");
        Destroy(gameObject);
        SceneManager.LoadScene("Perks", LoadSceneMode.Single);
        
    }
    /* Loads the Main Main Menu When exit is clicked in lobby */
    void Exit_Clicked()
    {
        //Debug.Log("Loading Main Menu");
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        
    }
}