using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // used to switch scenes

public class UIBoatsSunk : MonoBehaviour
{
    //Declarations
    public Text countText;  //Used for how many boats are sunk
    public Text TimeText;   //Used to show the end result once the test is over
    public virtual void IncreaseCount()
    {
        count++;
        countText.text = "Number of Boats Sunk: " + count.ToString();
        Alreadysunk = 1;
    }
    public float startTime = (Time.time+30); // Used to know when to switch scenes
    
    public float Alreadysunk = 0;
    public float count = 0;
    private IEnumerator coroutine;  //Used to wait
    public bool CoroutineStarted = false;   //Shows whether coroutine started or not
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        // Initializes the scene
       
        startTime = (Time.time+30);
        startPos = transform.position;
        countText.text = "Number of Boats Sunk: " + count.ToString();
        coroutine = WaitAndChangeScene(3.0f);
        //
        AnotherBoatSunk dy = new AnotherBoatSunk { };
        
    }

    // Update is called once per frame
    void Update()
    {
        //Counting number of boats that pass below a certain point
        countText.text = "Number of Boats Sunk: " + count.ToString();
        
        //Calculates if a boat goes below certain point and adds it to the count
        if(transform.position.y < -3 && Alreadysunk == 0){
            IncreaseCount();
        }
        
        // Once enough time has passed end the test
        if(Time.time > startTime)
        {
            StartCoroutine(coroutine);
            CoroutineStarted = true;
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
    // function to wait for the alloted time, and then switch to Josh's Test scene
    private IEnumerator WaitAndChangeScene(float time)
    {
        // Wait for (time), then switch sceens
        yield return new WaitForSeconds(time);
        Debug.Log("Returned from wait time");
        SceneManager.LoadScene("JDTest", LoadSceneMode.Single);
    }
}




public class AnotherBoatSunk: UIBoatsSunk
{
    public override void IncreaseCount()
    {
        countText.text = "Dynamic Number of Boats Sunk: " + count.ToString();
        base.IncreaseCount();
        
    }

}