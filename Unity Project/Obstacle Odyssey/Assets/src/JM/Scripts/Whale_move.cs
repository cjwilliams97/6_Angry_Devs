using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale_move : MonoBehaviour
{
    // Prototype Pattern -- Not used in this portion
    /*
    public interface Prototype // The upfront interface for what can be cloned
    {
        Prototype Clone(); // Used to create sub objects of class
    }

    public class ConcretePrototypeA: Prototype // Class A
    {
        public Prototype Clone()
        {
            return (Prototype)MemberwiseClone();    //clone object
        }
    }
    public class ConcretePrototypeB: Prototype  // Class B
    {
        public Prototype Clone()
        {
            return (Prototype)MemberwiseClone();    //clone object
        }
    }
    */
    //Declarations
    public float delta = 50.5f; 
    public float speed = .25f; // speed of the whale
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
       // Inilizing startPos
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // This block, makes it so that the whale moves back and forth
        Vector3 v = startPos;
        v.z += delta * Mathf.Sin(Time.time * speed);
        /* This was an attempt to make the whale rotate around, but did not look good
         * if(v.z > -664)
        {
            transform.Rotate(0, 0, 180);
        }
        if(v.z < -762)
        {
            transform.Rotate(0, 0, 180);
        }
        */
        transform.position = v;
        
    }
}
