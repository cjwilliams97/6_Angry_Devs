using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Material Green; // reference to green material initialization
    private Material Red; // reference to red material initialization
    bool flag = false;
    bool check1 = false;

    // Start is called before the first frame update
    void Start()
    {
        Green = Resources.Load("JD/Brandon/Green", typeof(Material)) as Material; // references green material location
        Red = Resources.Load("JD/Brandon/Red", typeof(Material)) as Material; // references red material location
        flag = false;
        check1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == false)
        {
            flag = true;
            StartCoroutine(Change());

            enabled = false; // stops calling update
        }
    }

    IEnumerator Change()
    {
        while (GameObject.Find("QuestionMark") != null) // searches for question mark object
        {
            yield return new WaitForSeconds(1.5f); // will wait 2 seconds

            if (check1 == false)
            {
                GetComponent<Renderer>().material = Red; // changes material to red
                check1 = true;
            }

            else
            {
                GetComponent<Renderer>().material = Green; // changes material to green
                check1 = false;
            }
        }
    }
}
