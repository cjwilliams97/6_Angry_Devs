﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Slowdown : MonoBehaviour
{
    bool InCollision = false;


    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame.
    void Update()
    {
        if (InCollision == true)
        {
            // Health = Health - 1;
        }
    }

    void OnCollisionEnter()
    {
        Player_Control.Max_Speed = 25;
        InCollision = true;

    }

    void OnCollisionExit()
    {
        Player_Control.Max_Speed = 100;
        InCollision = false;
    }

}
