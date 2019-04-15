using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SuccessInputTestCase : MonoBehaviour
{
    public Text TimeBetweenInputs;
    public Rigidbody rigid;
    public float Buffer = .001f; // amount to add between inputs
    private IEnumerator coroutine;
    private IEnumerator coroutine2;
    private bool CoroutineStarted = false;
    private bool CoroutineStarted2 = false;
    public Text Condition;
    public float timerunning;
    public float timescaler = .5f;
    public float Velocity;


    void Start()
    {
       rigid.GetComponent<Rigidbody>();
        Time.timeScale = timescaler;
        Time.fixedDeltaTime = timescaler;
       float safeVal = FailInputTestCase.TimeVal +Buffer;
       string temp = safeVal.ToString();
       TimeBetweenInputs.text = temp;
        coroutine = Timer(safeVal);
        coroutine2 = WaitAndChangeScene(2.5f);
        Condition.text = "Yes";
        Condition.color = Color.green;
    }
    private IEnumerator WaitAndChangeScene(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);

    }
    private IEnumerator Timer(float time)
    {

        while (timerunning < 10.0f && CoroutineStarted2 == false)
        {
            yield return new WaitForSeconds(time);
            rigid.GetComponent<Player_Control>().Forward();
        }
         
        
        
    }
    void Update()
    {
        if (CoroutineStarted == false)
        {
            StartCoroutine(coroutine);
            CoroutineStarted = true;
        }
        timerunning += Time.deltaTime;
        Velocity = rigid.velocity.magnitude;
        if (Velocity >= 100.0f)
        {
            if(CoroutineStarted2 == false)
            {
                StartCoroutine(coroutine2);
                CoroutineStarted2 = true;
            }
           
        } 
    }
}
