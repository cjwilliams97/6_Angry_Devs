using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSmoke : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject[] Particles;
    private float[] Speeds;
    private float[] Scales;
    private Texture Smoke_texture1;
    private Texture Smoke_texture2;
   
    void Start()
    {
        SmokeySmoke();
        return;
    }

    public void SmokeySmoke()
    {
        int amount = 150;   //number of particles to be spawned
        float range = 1f; //distance from origin when generating particles
        float speed = 3 * 0.1f; //upper limit for rising speed
        float ScaleFactor = 1f; //affects how quickly things shrink (high number = faster shrinking)
        float lifetime = 1f;    //upper limit of how long a particle can live for 
        float ThreshHold = .05f;   //minimum size a particle can be before it get auto destroyed
        SmokeySmoke(amount, range, speed, ScaleFactor, lifetime, ThreshHold);
    }

    private void SmokeySmokeRepeating()
    {
        InvokeRepeating("SmokeySmoke", 2.0f, 3.5f);
        return;
    }

    public void SmokeySmoke(int amount, float range, float speed, float ScaleFactor, float lifetime, float ThreshHold)
    {
        Smoke_texture1 = Resources.Load<Texture>("JD/Smoke/smoke_1");
        Smoke_texture2 = Resources.Load<Texture>("JD/Smoke/smoke_2");
        Particles = new GameObject[amount];

        Speeds = new float[amount];
        Scales = new float[amount];
        for (int i = 0; i < amount; i++)
        {
            Speeds[i] = Random.Range(speed / 16, speed);
            Scales[i] = Random.Range(ScaleFactor / 2, ScaleFactor);
        }

        StartCoroutine(Generate(amount, range, speed, ScaleFactor, lifetime, ThreshHold));
        StartCoroutine(Rise(amount, range, speed, ScaleFactor, lifetime, ThreshHold));
        StartCoroutine(Kill(amount, range, speed, ScaleFactor, lifetime, ThreshHold));
        return;
    }

    private IEnumerator Generate(int amount, float range, float speed, float ScaleFactor, float lifetime, float ThreshHold)
    {
        float time = 0;
        if (time >= lifetime * 2)
            yield break;
        for (int i = 0; i < amount; i++)
        {
            //generates an equal distribution of medium and smoke particles
            if(i % 2 == 0)
              Particles[i] = Instantiate(Resources.Load("JD/Smoke/smoke_medium", typeof(GameObject)), transform.position, this.transform.rotation, this.transform) as GameObject;
            else
                Particles[i] = Instantiate(Resources.Load("JD/Smoke/smoke_small", typeof(GameObject)), transform.position, this.transform.rotation, this.transform) as GameObject;
 
            //assigns textures half and half to particles
            if (i % 2 == 0)
                Particles[i].gameObject.GetComponent<Renderer>().material.mainTexture = Smoke_texture1;
            else
                Particles[i].gameObject.GetComponent<Renderer>().material.mainTexture = Smoke_texture2;

            //sets particles position to a random place within the range
            Particles[i].transform.position = this.transform.position;
            Particles[i].transform.position -= new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), transform.position.y, Random.Range(transform.position.z - range, transform.position.z + range));

            //sets a random scale factor for the particles to decrease by
            Particles[i].transform.localScale = Vector3.one * Scales[i] * 100;

            time += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator Rise(int amount, float range, float speed, float ScaleFactor, float lifetime, float ThreshHold)
    {
        float time = 0;
        if (time >= lifetime * 2)
            yield break;
        for (; ;)
        {
            time += Time.deltaTime;
            for (int i = 0; i < amount; i++)
            {
                try
                {
                    //rise particle by the generated random speed about  
                    Particles[i].transform.Translate(0, Speeds[i], 0);
                     //decrease scale by generated scale amount
                     Particles[i].transform.localScale -= new Vector3(Scales[i], Scales[i], Scales[i]);
                    //if particle size is ever smaller than threshold destroy the object
                    if (Particles[i].transform.localScale.x <= ThreshHold)
                        Destroy(Particles[i]);
                }
                catch
                { }
            }
            yield return null;
        }
    }

    private IEnumerator Kill(int amount, float range, float speed, float ScaleFactor, float lifetime, float ThreshHold)
    {
        float time = 0;
        if (time >= lifetime * 2)
            yield break;
        while (time <= lifetime)
        {
            time += Time.deltaTime;
            yield return null;
        }
        //kill all particles if lifetime has expired
        foreach (var particle in Particles)
        {
            Destroy(particle);
            yield return null;
        }
    }
}
