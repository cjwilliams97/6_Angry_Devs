using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Control : MonoBehaviour
{
    public float Max_Speed;
    public float Foward_Speed;
    public float Brake_Speed;
    public float Responsiveness;

    public float Turn_Speed;
    //scale from 0-1 

    public float Pitch_Force;
    
    public float Brake_Force;

    public float Accel_Force;
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
                    rigid.AddTorque(0.0f,Accel_Force,0.0f);
                }
            }
            if(Input.GetKey("S")){
                rigid.AddForce(- (Brake_Speed* Responsiveness));
                rigid.AddTorque(0.0f,-(Brake_Force),0.0f);
            }
            if(Input.GetKey("A")){
                rigid.AddForce(0.0f,Turn_Speed * Responsiveness);
                rigid.AddTorque(Pitch_Force,0.0f,0.0f);
            }
            if(Input.GetKey("D")){
                rigid.AddForce(0.0f,-(Turn_Speed * Responsiveness));
                rigid.AddTorque(-(Pitch_Force),0.0f,0.0f);
            }
    
    }
}