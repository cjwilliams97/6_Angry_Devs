using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FailInputTestCase : MonoBehaviour
{
    public Text TimeBetween;
    public Rigidbody rigid;
    static public float TimeVal = .5f;
    private float OldVelocity;
    private float NewVelocity;
    public float TimeScaler = .1f;
    public bool Failed = false;
    public bool firstFrame = true;
    public Text Condition;
    public bool CoroutineStarted = false;
    private IEnumerator coroutine;
    public float framecount;
  
    void Start()
    {
        rigid.GetComponent<Rigidbody>();
        firstFrame = true;
        Failed = false;
        CoroutineStarted = false;
        framecount = 0;
        
        TimeVal = .25f;
        TimeBetween.text = "0.000";
        Condition.text = "Yes";
        Condition.color = Color.green;
        coroutine = WaitAndChangeScene(5.0f);
        
        
        
        
    }
    void Update()
    {
        if(firstFrame == false)
        {
            Time.timeScale = TimeScaler;
            Time.fixedDeltaTime = TimeScaler;
           
            if (Failed == false)
                {
                if (TimeVal > 0.002f)
                {
                    TimeVal -= Time.deltaTime * TimeScaler;
                    string temp = TimeVal.ToString();
                    TimeBetween.text = temp;

                    OldVelocity = rigid.velocity.magnitude;


                    if (OldVelocity == NewVelocity)
                    {
                        Failed = true;

                    }
                }
                if (TimeVal < .005f)
                {
                    Failed = true;
                }
            }
                
            if(Failed == true)
            {
                Condition.text = "No";
                Condition.color = Color.red;
                

            }
        }
        else
        {
            if (framecount < 25)
            {
                framecount++;
            }
            else
            {
                firstFrame = false;
            }
            
        }
    }
    void FixedUpdate()
    {
        if(TimeVal > 0.05f && Failed == false)
        {
            rigid.GetComponent<Player_Control>().Forward();
            NewVelocity = rigid.velocity.magnitude;
        }           
        if( Failed == true)
        {
            TimeScaler = 1.0f;
            Debug.Log("Failed State Triggered");
            if (CoroutineStarted == false)
            {
                StartCoroutine(coroutine);
                Debug.Log("Started Coroutine");
                CoroutineStarted = true;
            }
            
        }
    }

    private IEnumerator WaitAndChangeScene(float time)
    {
        yield return new WaitForSeconds(time);
        //Debug.Log("Returned from wait time");
        SceneManager.LoadScene("SLSucessTest", LoadSceneMode.Single);
    }
    public float MaxInputValue()
    {
        return TimeVal;
    }
}
