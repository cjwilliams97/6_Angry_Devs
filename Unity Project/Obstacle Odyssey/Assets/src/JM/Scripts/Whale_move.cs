using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale_move : MonoBehaviour
{
    public float delta = 50.5f;
    public float speed = .25f;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = startPos;
        v.z += delta * Mathf.Sin(Time.time * speed);
        /*if(v.z > -664)
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
