using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_Sway : MonoBehaviour
{
    //Declarations
    public float delta_y = 1.5f; // speed for y direction
    public float delta = 3f;    // speed for z direction
    public float speed = 2.0f;  // general speed
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        // initilizing startPos
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       // This block, changes the movement of the barrel, so that it is swaying
        Vector3 v = startPos;
        v.z += delta * Mathf.Sin(Time.time * (speed/2));
        v.y += delta_y * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
