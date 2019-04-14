/* Checks for the player health every frame, sets a IsFailed Flag if player has died
 * Proceedes to sink ship and enable 'esc' backing to lobby */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{
    public Rigidbody rigid;         // The ship's rigidbody
    private float health;           // The Player's health, accessed through Health.cs
    public GameObject reference;    // Refrence Gameobject for Health Interaction
    private bool FirstFrame = true;
    private IEnumerator coroutine;
    public GameObject Text;         // The GameOver Text
    public GameObject TimerHudText; // The Text for the timer
    public GameObject TimerHudBackground; //The background Image for Timer
    public GameObject RearMastFire;     //Fire Elements for each mast
    public GameObject FrontMastFire;    //Fire Elements for each mast
    private KeyCode Escape = KeyCode.Escape;
    public static bool IsFailed = false;


    void Start()
    {
        FirstFrame = true;
        coroutine = Wait(2.0f);
        rigid = GetComponent<Rigidbody>();
        rigid.GetComponent<BoatProbes>()._forceMultiplier = 16.0f;
        Text.SetActive(false);


    }

    private void Awake()
    {
        IsFailed = false;

    }

    void LateUpdate()
    {
        /* Waits a few seconds on first frame to start checking for player death */
        if (FirstFrame == true)
        {
            StartCoroutine(coroutine);
            //Debug.Log("Coroutine Started");
        }
        /* General Execution of script */
        if (FirstFrame == false)
        {
            health = reference.GetComponent<Health>().ReturnHealth();
            /* Checks for health being <= 0, starts player "death" if true */
            if (health <= 0)
            {
                //Debug.Log("Player has lost");
                SinkShip();
            }
        }
        /* If Flag for failed game is thrown, on exit unload to lobby */
        if (Input.GetKey(Escape))
        {
            if (IsFailed == true)
            {
                SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
            }
        }


    }

    /* Changes the physics properties to simulate sinking */
    /* Also Removes Timer, Stops user input, and catches boat on fire */
    /* Finally sets a IsFailed flag to true */
    public bool SinkShip()
    {
        // Debug.Log("Sinking Ship");
        rigid.GetComponent<BoatProbes>()._forceMultiplier = .85f;
        rigid.GetComponent<BoatProbes>()._playerControlled = false;
        Text.SetActive(true);
        TimerHudBackground.SetActive(false);
        TimerHudText.SetActive(false);
        FrontMastFire.SetActive(true);
        RearMastFire.SetActive(true);

        IsFailed = true;
        return true;
    }
    /* Prevents Dieing in first 2 seconds of game, allows setup of other objects first */
    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);

        FirstFrame = false;
    }
}
