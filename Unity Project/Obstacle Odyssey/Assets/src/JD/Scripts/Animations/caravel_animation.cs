using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Currently Legacy code:
 * The caravel_animation code allows for the attached gameobject to sway back and forth
 * inheriting the superclasses sway function. Currently not in live game due to physics
 * engine changes
 */
  
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