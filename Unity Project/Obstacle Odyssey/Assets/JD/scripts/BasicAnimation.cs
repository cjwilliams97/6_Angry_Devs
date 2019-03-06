using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    protected Vector3[] RandomIncrements = new Vector3[10];
    protected int cycle = 0;
    public virtual IEnumerator Sway(bool state, float threshhold, float turnTime)
    {
        if (state)
        {
            float time = 0;
            for (; ; )
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