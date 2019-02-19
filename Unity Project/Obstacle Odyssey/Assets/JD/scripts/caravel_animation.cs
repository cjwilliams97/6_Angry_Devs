using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caravel_animation : MonoBehaviour
{
    private Vector3[] RandomIncrements = new Vector3[10];
    public float turnTime = 7f;
    public float threshhold = 0.5f;
    private int cycle;

    void Start()
    {
        cycle = 0;
        for (int i = 0; i < 10; i++)
        {
            RandomIncrements[i] = new Vector3(Random.Range(-threshhold, threshhold) * Time.deltaTime,
                                             Random.Range(-threshhold, threshhold) * Time.deltaTime,
                                               Random.Range(-threshhold, threshhold) * Time.deltaTime);
        }
        StartCoroutine(Sway());
    }
    IEnumerator Sway()
    {

        
        Vector3 turnIncrement = new Vector3(Random.Range(-threshhold, threshhold) * Time.deltaTime,
                                             Random.Range(-threshhold, threshhold) * Time.deltaTime, 
                                               Random.Range(-threshhold, threshhold) * Time.deltaTime);
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
}