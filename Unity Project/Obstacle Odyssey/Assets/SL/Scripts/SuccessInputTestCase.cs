using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SuccessInputTestCase : MonoBehaviour
{
    public Text TimeBetweenInputs;
    public Rigidbody rigid;

    void Start()
    {
        rigid.GetComponent<Rigidbody>();
        float safeVal = rigid.GetComponent<FailInputTestCase>().MaxInputValue();
        string temp = safeVal.ToString();
        TimeBetweenInputs.text = temp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
