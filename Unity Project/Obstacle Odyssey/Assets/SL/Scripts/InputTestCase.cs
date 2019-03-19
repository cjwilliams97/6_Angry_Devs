using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTestCase : MonoBehaviour
{
    public Text TimeBetween;
    public float Time = 1.00;
    public float Increment = .05;
    // Start is called before the first frame update
    void Start()
    {
        TimeBetween.text = "0.000";   
    }

    void FixedUpdate()
    {
        float i;
        for (i = Time; i > 0; i-Increment)
        {
            string temp = Time.ToString();
            TimeBetween.text = temp;
            Time - Increment;
        }
    }
}
