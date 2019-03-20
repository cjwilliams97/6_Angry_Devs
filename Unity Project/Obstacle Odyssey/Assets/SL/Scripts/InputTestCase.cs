using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTestCase : MonoBehaviour
{
    public Text TimeBetween;
    public Rigidbody rigid;
    private float TimeVal = .5f;
    private float OldVelocity;
    private float NewVelocity;
    public float TimeScaler = .1f;
    public bool Failed = false;
    public bool firstFrame = true;
    public Text Condition;
  
    void Start()
    {
        rigid.GetComponent<Rigidbody>();
        TimeBetween.text = "0.000";
        Condition.text = "Yes";
        Condition.color = Color.green;
        
        
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
            firstFrame = false;
        }
    }
    void FixedUpdate()
    {
        if(TimeVal > 0.05f && Failed == false)
        {
            rigid.GetComponent<Player_Control>().Forward();
            NewVelocity = rigid.velocity.magnitude;
        }
        
      

        

    }



}
