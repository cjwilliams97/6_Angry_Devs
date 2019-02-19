using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSmoke : MonoBehaviour
{
    // Start is called before the first frame update
    public int amount;
    public float range;
    public float speed;
    public float ScaleFactor;
    public float lifetime;

    public float ThreshHold;
    public GameObject[] Particles;
    private float[] Speeds;
    private float[] Scales;
    private float Scale;
    public Texture Smoke_texture1;
    public Texture Smoke_texture2;

    void Start()
    {
        amount = 250;
        range = 3f; //distance from origin when generating particles
        speed = 0.1f;
        ScaleFactor = 0.5f;
        lifetime = 3f;
        ThreshHold = .05f;

        Smoke_texture1 = Resources.Load<Texture>("JD/Smoke/smoke_1");
        Smoke_texture2 = Resources.Load<Texture>("JD/Smoke/smoke_2");
        Particles = new GameObject[amount];

        Speeds = new float[amount];
        Scales = new float[amount];
        for (int i = 0; i < amount; i++)
        {
            Speeds[i] = Random.Range(speed / 16, speed);
            Scales[i] = Random.Range(ScaleFactor / 8, ScaleFactor);
        }

        StartCoroutine(Generate());
        StartCoroutine(Rise());
        StartCoroutine(Kill());
        return;
    }

    IEnumerator Generate()
    {
        for (int i = 0; i < amount; i++)
        {
            Particles[i] = Instantiate(Resources.Load("JD/Smoke/smoke_large", typeof(GameObject))) as GameObject;
            Particles[i].transform.parent = this.transform;

            if (i % 2 == 0)
                Particles[i].gameObject.GetComponent<Renderer>().material.mainTexture = Smoke_texture1;
            else
                Particles[i].gameObject.GetComponent<Renderer>().material.mainTexture = Smoke_texture2;
            Particles[i].transform.position = new Vector3(Random.Range(-range, range), Random.Range(-range / 2, range / 2), Random.Range(-range, range));
            Scale = Random.Range(ScaleFactor / 16, ScaleFactor);
            Particles[i].transform.localScale += new Vector3(Scale, Scale, Scale);
            yield return new WaitForSeconds(Random.Range(0, lifetime / 128));
        }
    }

    IEnumerator Rise()
    {
        for (; ; )
        {
            for (int i = 0; i < amount; i++)
            {
                try
                {
                    Particles[i].transform.position += new Vector3(0, Speeds[i], 0);
                    Particles[i].transform.localScale -= new Vector3(Scales[i], Scales[i], Scales[i]);
                    if (Particles[i].transform.localScale.x <= ThreshHold)
                        Destroy(Particles[i]);
                }
                catch
                {

                }
            }
            yield return null;
        }
    }

    IEnumerator Kill()
    {
        float time = 0;
        while (time <= lifetime * 2)
        {
            time += Time.deltaTime;
            yield return null;
        }
        for (int i = 0; i < amount; i++)
        {
            try
            {
                Destroy(Particles[i]);
            }
            catch
            {

            }
            yield return null;
        }
    }
}
