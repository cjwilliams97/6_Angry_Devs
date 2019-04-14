using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * The barrel_animation subclass can be attached to an object to give it the appreance
 * of it rocking side to side while bobbing up and down
 */ 
public class barrel_animation : MonoBehaviour
{
    public float speed;   //turning speed 
    public float Intensity; //intensity of the turn
    public float threshhold;
    private Vector3 Increment;
    public float TurnTime;    //how long the cycle goes for

    private Vector3[] RandomIncrements = new Vector3[5];
    private int cycle;

    void Start()
    {

        speed = 5f;
        Intensity = 0.05f;
        threshhold = 2f;
        TurnTime = 10f;
        Increment = new Vector3(0.0f, Intensity * 0.1f, 0.0f);

        for(int i = 0; i < 5; i++)
        {
            RandomIncrements[i] = new Vector3(Random.Range(-threshhold, threshhold) * Time.deltaTime, Random.Range(-threshhold, threshhold) * Time.deltaTime, 0);
        }
        cycle = 0;
        StartCoroutine(Rock());
        StartCoroutine(Bob());
    }

    IEnumerator Rock()
    {
        float time = 0;
        while (time < TurnTime)
        {
            time += Time.deltaTime;
            transform.Rotate(RandomIncrements[cycle % 5], Space.World);
            yield return null;
        }

        while (time > 0)
        {
            time -= Time.deltaTime;
            transform.Rotate(-RandomIncrements[cycle % 5], Space.World);
            yield return null;
        }
        cycle++;
    }

    IEnumerator Bob()
    {
        float time = 0;
        for (; ;)
        {
            while (time < TurnTime)
            {
                time += Time.deltaTime;
                transform.position += Increment;
                yield return null;
            }

            while (time > 0)
            {
                time -= Time.deltaTime;
                transform.position -= Increment;
                yield return null;
            }
        }
    }
}
