using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caravel_animation : BasicAnimation
{
    private void Start()
    {
        IdleShip(true, 1f, 5f);
    }

    /*
    private Vector3[] RandomIncrements = new Vector3[10];
    private int cycle;
    */
    //starts ship idle animation when IdleShip is called with true passed as a parameter 
    private void IdleShip(bool state, float threshhold, float turnTime)
    {
        for (int i = 0; i < 10; i++)
        {
            RandomIncrements[i] = new Vector3(Random.Range(-threshhold, threshhold) * Time.deltaTime,
                                             Random.Range(-threshhold, threshhold) * Time.deltaTime,
                                               Random.Range(-threshhold, threshhold) * Time.deltaTime);
        }

        if (state)
            StartCoroutine(base.Sway(state, threshhold, turnTime));
        return;
    }
}