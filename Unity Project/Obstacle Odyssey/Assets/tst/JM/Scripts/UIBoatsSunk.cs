using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBoatsSunk : MonoBehaviour
{
    public float startTime = (Time.time+30);
    public Text countText;
    public Text TimeText;
    public float Alreadysunk = 0;
    public float count = 0;
    private IEnumerator coroutine;
    public bool CoroutineStarted = false;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startTime = (Time.time+30);
        startPos = transform.position;
        countText.text = "Number of Boats Sunk: " + count.ToString();
        coroutine = WaitAndChangeScene(3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Counting number of boats that pass below a certain point
        countText.text = "Number of Boats Sunk: " + count.ToString();
        // && alreadySunk == 0
        if(transform.position.y < -3 && Alreadysunk == 0){
            count++;
            countText.text = "Number of Boats Sunk: " + count.ToString();
            Alreadysunk = 1;
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
    private IEnumerator WaitAndChangeScene(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Returned from wait time");
        SceneManager.LoadScene("JDTest", LoadSceneMode.Single);
    }
}
