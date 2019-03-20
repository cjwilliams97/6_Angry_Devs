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


    void Start()
    {
       rigid.GetComponent<Rigidbody>();
       float safeVal = FailInputTestCase.TimeVal +Buffer;
       string temp = safeVal.ToString();
       TimeBetweenInputs.text = temp;
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
}
