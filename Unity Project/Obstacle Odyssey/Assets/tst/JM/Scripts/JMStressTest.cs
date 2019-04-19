using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JMStressTest : MonoBehaviour
{
    //Implementing Prototype Pattern
    abstract class WhalePrototype // Interface for Prototype
    {
        public abstract WhalePrototype Clone();
    }
    //Create a subclass with speed as variable
    class Whale: WhalePrototype
    {
        
        private float speed = .25f; // Initial speed of whale
        //Method, for changing whale values
        public Whale(float Speed)
        {
            speed = Speed; //Change speed to desired value
        }
        // method, for cloning whale with new speed
        public override WhalePrototype Clone()
        {
            System.Console.WriteLine("Cloning Whale with new Speed");
            return MemberwiseClone() as WhalePrototype;
        }
    }
    

    //Declarations
    public Text speedText;
    public float count = 0; //Initialize how many boats are sunk to 0
    public float SpeedInc = .025f; // speed at which the whales increase
    public float delta = 50.5f;
    public float speed = .25f;  // Initial speed of whale
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        //Initialize startPos, and the text for showing whale speed
        startPos = transform.position;
        speedText.text = "Whale Speed: " + speed.ToString();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        // Increases whale speed and updates the text showng speed
        speed += SpeedInc * Time.deltaTime;
        speedText.text = "Whale Speed: " + speed.ToString();
        Vector3 v = startPos;
        v.z += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
