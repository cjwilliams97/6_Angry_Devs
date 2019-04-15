using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VelocityUI : MonoBehaviour
{
    public Rigidbody rigid;
    public Text VelocityValue;
    public float Velocity;
    public bool firstFrame = true;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        VelocityValue.text = "000.00";
    }

    // Update is called once per frame
    void Update()
    {
        if (firstFrame == false)
        {
            Velocity = rigid.velocity.magnitude;
            string temp = Velocity.ToString();
            VelocityValue.text = temp;
        }
        else
        {
            firstFrame = false;
        }


    }
    public float CurrentVelocity()
    {
        return Velocity;
    }
}
   
