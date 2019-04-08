using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseCondition : MonoBehaviour
{
    public Rigidbody rigid;
    private float health;
    public GameObject reference;
    private bool FirstFrame = true;
    private IEnumerator coroutine;
    public GameObject Text;
    public GameObject TimerHudText;
    public GameObject TimerHudBackground;
    public GameObject RearMastFire;
    public GameObject FrontMastFire;
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
        if (FirstFrame == true)
        {
            StartCoroutine(coroutine);
            //Debug.Log("Coroutine Started");
        }

        if (FirstFrame == false) 
        {
            health = reference.GetComponent<Health>().ReturnHealth();
            //Debug.Log("Returned health is :" + health);
            if (health <= 0) //test for health <= 0
            {
                //Debug.Log("Player has lost");
                SinkShip();
            }
        }
        if (Input.GetKey(Escape))
        {
            if(IsFailed == true)
            {
                SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
            }
        }

        
    }
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
        return true ;
    }
    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);

        FirstFrame = false;
    }
}
