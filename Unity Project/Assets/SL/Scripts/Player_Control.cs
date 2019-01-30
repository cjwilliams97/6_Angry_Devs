using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Control: MonoBehaviour
{
    public float Max_Speed;
    public float Foward_Speed;
    public float Brake_Speed;
    public float Responsiveness;

    public float Turn_Sensitivity;
    
    private Rigidbody rigid;
    void start(){
        rigid =  GetComponent<Rigidbody>();
    }
    void Update()
    {
            float xVel =  transofrm.InverseTransformDirection(rigid.velocity).x;
            if(Input.GetKey("W")){
                if(xVel < Max_Speed){
                    rigid.AddForce(Foward_Speed * Responsiveness);
                }
            }
            if(Input.GetKey("S")){
                rigid.AddForce(- (Brake_Speed* Responsiveness));
            }
            if(Input.GetKey("A")){
                rigid.AddForce(0.0f,Turn_Sensitivity * Responsiveness);
            }
            if(Input.GetKey("D")){
                rigid.AddForce(0.0f,-(Turn_Sensitivity * Responsiveness));
            }
    
    }
}