using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimation : MonoBehaviour
{
    public float speed = 5f;
    public float Intensity = 0.0005f;
    private Vector3 Increment;
    public float TurnTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Increment = new Vector3(0.0f, Intensity * 0.1f, 0.0f); ;
        StartCoroutine(Turn());
        StartCoroutine(Bob());
    }

    IEnumerator Turn()
    {
        for (; ;)
        {
            transform.Rotate(Vector3.right * 0.5f, speed * Time.deltaTime);
            yield return null;
        }
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
