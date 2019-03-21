using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    static public float Max_Speed = 100;
    public float Accel_Rate = 500;
    public float Decel_Rate = 500;
    public float Turn_Rate  = 250;
    public float Turn_Speed = 5.0f;
    public float Bank_Scale = 8.0f;
    public float Velocity;
    public Rigidbody rigid;
    private KeyCode Accelerate = KeyCode.W;
    private KeyCode Port = KeyCode.A;
    private KeyCode Starboard = KeyCode.D;
    private KeyCode Decelerate = KeyCode.S;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Velocity = rigid.velocity.magnitude;
    }

    void Update()
    {
        
        if(Input.GetKey(Accelerate))
        {
            Forward();
           
        }
        if(Input.GetKey(Port))
        {
            Left();
        }
        if (Input.GetKey(Starboard))
        {
            Right();
        }
        if (Input.GetKey(Decelerate))
        {     
            Slow(); 
        }
    }
    /*
     * Takes a float to set max speed of vessle
     * Returns the previous max speed as a float
     * if you want to return to the previous max 
     * speed save this value, and reset it by calling
     * it again with the saved val
     */
    public float SetMaxSpeed(float x)
    {
        float oldSpeed = Max_Speed;
        Max_Speed = x;
        return oldSpeed;
    }
    public void Forward()
    {
        Vector3 vel = rigid.velocity;
        if (vel.magnitude < Max_Speed)
        {
            //Debug.Log("Speeding up");
            rigid.AddRelativeForce(Accel_Rate, 0.0f, 0.0f);
        }
    }
    public void Slow()
    {
        //Debug.Log("Slowing Down");
        rigid.AddRelativeForce(-Decel_Rate, 0.0f, 0.0f);
    }
    public void Left()
    {
        //Debug.Log("Turning Left");
        rigid.AddRelativeForce(0.0f, 0.0f, Turn_Rate);
        //transform.Rotate(Vector3.left * Time.deltaTime * 10.0f);
        transform.Rotate(0.0f, -Time.deltaTime * Bank_Scale, 0.0f, Space.World);
    }
    public void Right()
    {
        // Debug.Log("Turning Right");
        rigid.AddRelativeForce(0.0f, 0.0f, -Turn_Rate);
        //transform.Rotate(Vector3.right * Time.deltaTime * 10.0f);
        transform.Rotate(0.0f, Time.deltaTime * Bank_Scale, 0.0f, Space.World);
    }
    
}
