using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float Max_Speed;
    public float Accel_Rate;
    public float Decel_Rate;
    public float Turn_Rate;
    public Rigidbody rigid;
    private KeyCode Accelerate = KeyCode.W;
    private KeyCode Port = KeyCode.A;
    private KeyCode Starboard = KeyCode.D;
    private KeyCode Decelerate = KeyCode.S;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(Accelerate))
        {
            Debug.Log("Speeding up");
            rigid.AddForce(Accel_Rate, 0.0f, 0.0f);
        }
        if(Input.GetKeyDown(Port))
        {
            Debug.Log("Turning Left");
            rigid.AddForce(0.0f, 0.0f, Turn_Rate);
        }
        if (Input.GetKeyDown(Starboard))
        {
            Debug.Log("Turning Right");
            rigid.AddForce(0.0f, 0.0f, -Turn_Rate);
        }
        if (Input.GetKeyDown(Decelerate))
        {
            Debug.Log("Slowing Down");
            rigid.AddForce(-Decel_Rate, 0.0f, 0.0f);
        }
    }
}
