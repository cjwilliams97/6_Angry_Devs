using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caravel_animation : MonoBehaviour
{
    private Vector3[] RandomIncrements = new Vector3[10];
    private int cycle;

    //starts ship idle animation when IdleShip is called with true passed as a parameter 
    void IdleShip(bool state, float threshhold, float turnTime)
    {
        cycle = 0;
        for (int i = 0; i < 10; i++)
        {
            RandomIncrements[i] = new Vector3(Random.Range(-threshhold, threshhold) * Time.deltaTime,
                                             Random.Range(-threshhold, threshhold) * Time.deltaTime,
                                               Random.Range(-threshhold, threshhold) * Time.deltaTime);
        }

        if (state)
            StartCoroutine(Sway(state, threshhold, turnTime));
        return;
    }

    IEnumerator Sway(bool state, float threshhold, float turnTime)
    {
        if (state)
        {
            float time = 0;
            for (; ;)
            {
                while (time < turnTime)
                {
                    time += Time.deltaTime;
                    transform.Rotate(RandomIncrements[cycle % 10]);
                    yield return null;
                }

                while (time > 0)
                {
                    time -= Time.deltaTime;
                    transform.Rotate(-RandomIncrements[cycle % 10]);
                    yield return null;
                }
                cycle++;
            }
        }
        else
        {
            yield return null;
        }
    }
}