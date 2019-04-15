using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // allows text manipulation
using UnityEngine.SceneManagement;

public class StatePatternTesting : MonoBehaviour
{
    public Text PatternText1; // creates the Text object which is attached to HUD canvas
    public Text PatternText2; // creates the Text object which is attached to HUD canvas
    public Text PatternText3; // creates the Text object which is attached to HUD canvas

    float valueX;
    float valueY;
    float valueZ;
    bool check = false;
    bool flag = false;
    private IEnumerator coroutine;

    void Awake()
    {
        valueX = this.gameObject.transform.position.x;
        valueY = this.gameObject.transform.position.y;
        valueZ = this.gameObject.transform.position.z;
        PatternText1.text = "Initial Location: x =  " + valueX + ", y =  " + valueY + ", z =  " + valueZ;
    }
    // Start is called before the first frame update
    void Start()
    {
        valueX = this.gameObject.transform.position.x;
        valueY = this.gameObject.transform.position.y;
        valueZ = this.gameObject.transform.position.z;
        check = false;
        PatternText2.text = "New Location: y =  " + valueX + ", y =  " + valueY + ", z =  " + valueZ;
        coroutine = WaitAndChangeScene(10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(check == true)
        {
            if (flag == false)
            {
                StartCoroutine(coroutine);
                //enabled = false;
            }

            flag = true;
        }

        valueX = this.gameObject.transform.position.x;
        valueY = this.gameObject.transform.position.y;
        valueZ = this.gameObject.transform.position.z;
        PatternText2.text = "New Location: X =  " + valueX + ", y =  " + valueY + ", z =  " + valueZ;

        if (valueX <= 2.5 && valueY <= 5.5 && valueZ <= 2.5 && valueX >= -2.5
                        && valueY >= 0 && valueZ >= -2.5)
        {
            if (check == false)
            {
                check = true;
            }
            PatternText3.color = Color.green;
            PatternText3.text = "Successfully moved ship to standard starting location";
        }

        else if (valueX >= 2 || valueY >= 5.5 || valueZ >= 2 || valueX <= -2
                        || valueY <= 3.5 || valueZ <= -2)
        {
            PatternText3.color = Color.red;
            PatternText3.text = "Failed to moved ship to standard starting location";
        }
    }

    private IEnumerator WaitAndChangeScene(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Returned from wait time");
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
}
