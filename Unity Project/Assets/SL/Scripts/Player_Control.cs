using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Control: MonoBehaviour
{
    public float speed;
    private Rigidbody rigid;
    void start(){
        rigid =  GetComponent<Rigidbody>();
    }
    void Update()
    {
    
    }
}