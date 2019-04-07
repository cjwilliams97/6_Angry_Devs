using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoseCondition : MonoBehaviour
{
    public Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        
        rigid.GetComponent<BoatProbes>()._forceMultiplier = 16.0f;

    }

    // Update is called once per frame
    void Update()
    {
        //get the current health
        if (Input.GetKey(KeyCode.T)) //test for health == 0
        {
            SinkShip();
        }
        
    }
    public bool SinkShip()
    {
        
        rigid.GetComponent<BoatProbes>()._forceMultiplier = .85f;
        rigid.GetComponent<BoatProbes>()._playerControlled = false;
        return true ;
    }
}
