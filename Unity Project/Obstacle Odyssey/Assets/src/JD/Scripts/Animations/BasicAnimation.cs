using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * The following file is a Basic Animation class containing animation(s) that are frequently
 * used by its subclasses.
 */ 
public class BasicAnimation : MonoBehaviour
{

    protected Vector3[] RandomIncrements = new Vector3[10];
    protected int cycle = 0;
    public virtual IEnumerator Sway(bool state, float threshhold, float turnTime)
    {
        if (state)
        {
            float time = 0;
            for ( ; ; )
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