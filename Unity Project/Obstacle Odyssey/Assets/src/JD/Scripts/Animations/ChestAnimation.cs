using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The chest Animation subclass allows for the attached gameobject to rotate and bob up and down
 */ 
public class ChestAnimation : BasicAnimation
{
    private float speed = 10f;
    private float Intensity = 0.005f;
    private Vector3 Increment;
    private float TurnTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
       Increment = new Vector3(0.0f, Intensity * 0.1f, 0.0f);
       StartCoroutine(Turn(speed));
       StartCoroutine(Bob(TurnTime));
    }
   
    private IEnumerator Turn(float speed)
    {
        for (; ;)
        {
            transform.Rotate(Vector3.right * 0.5f, speed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator Bob(float turnTime)
    {
        float time = 0;
        for (; ;)
        {
            while (time < turnTime)
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
