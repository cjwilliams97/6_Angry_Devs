using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestCaseReset : MonoBehaviour
{
    public Rigidbody rigid;
    private KeyCode Reset = KeyCode.Space;
    // Start is called before the first frame update
    void Start()
    {
        rigid.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Reset))
        {
            SceneManager.LoadScene("SLFailedTest");
        }
    }
}
