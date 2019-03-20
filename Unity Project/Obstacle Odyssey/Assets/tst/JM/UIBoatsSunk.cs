using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBoatsSunk : MonoBehaviour
{
    public Text countText;
    public Text TimeText;
    private int alreadySunk = 0;
    public float count = 0;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        countText.text = "Number of Boats Sunk: " + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Counting number of boats that pass below a certain point
        countText.text = "Number of Boats Sunk: " + count.ToString();
        // && alreadySunk == 0
        if(transform.position.y < -10){
            count++;
            countText.text = "Number of Boats Sunk: " + count.ToString();
            alreadySunk = 1;
        }
        // Once enough time has passed end the test
        if(Time.time > 45)
        {
            if(count < 5)
            {
                TimeText.text = "Only " + count.ToString() + " Boat(s) sunk, Test Passed ";
            }
            else
            {
                TimeText.text = count.ToString() + " Boat(s) sunk, Test Failed ";
            }
        }
    }
}
