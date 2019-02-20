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
        int amount = 200;   //number of particles to be spawned
        float range = 2f; //distance from origin when generating particles
        float speed = 0.15f; //upper limit for rising speed
        float ScaleFactor = 1f; //affects how quickly things shrink (high number = faster shrinking)
        float lifetime = 3f;    //upper limit of how long a particle can live for 
        float ThreshHold = .05f;   //minimum size a particle can be before it get auto destroyed

        SmokeySmoke(amount, range, speed, ScaleFactor, lifetime, ThreshHold);
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
            Scales[i] = Random.Range(ScaleFactor / 8, ScaleFactor);
        }

        StartCoroutine(Generate(amount, range, speed, ScaleFactor, lifetime, ThreshHold));
        StartCoroutine(Rise(amount, range, speed, ScaleFactor, lifetime, ThreshHold));
        StartCoroutine(Kill(amount, range, speed, ScaleFactor, lifetime, ThreshHold));
        return;
    }

    IEnumerator Generate(int amount, float range, float speed, float ScaleFactor, float lifetime, float ThreshHold)
    {
        for (int i = 0; i < amount; i++)
        {
            //generates an equal distribution of medium and smoke particles
            if(i % 2 == 0)
              Particles[i] = Instantiate(Resources.Load("JD/Smoke/smoke_medium", typeof(GameObject)), transform.position, transform.rotation, this.transform) as GameObject;
            else
                Particles[i] = Instantiate(Resources.Load("JD/Smoke/smoke_small", typeof(GameObject)), transform.position, transform.rotation, this.transform) as GameObject;

            //Particles[i].transform.parent = this.transform; //sets parent to object script is placed on

            //assigns textures half and half to particles
            if (i % 2 == 0)
                Particles[i].gameObject.GetComponent<Renderer>().material.mainTexture = Smoke_texture1;
            else
                Particles[i].gameObject.GetComponent<Renderer>().material.mainTexture = Smoke_texture2;

            //sets particles position to a random place within the range
            Particles[i].transform.position = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), transform.position.y, Random.Range(transform.position.z - range, transform.position.z + range));

            //sets a random scale factor for the particles to decrease by
            float Scale = Random.Range(ScaleFactor / 16, ScaleFactor);
            Particles[i].transform.localScale += new Vector3(Scale, Scale, Scale);
            //delays for a small amount of time based on lifetime
            //yield return new WaitForSeconds(Random.Range(0, lifetime / 256));
            yield return null;
        }
    }

    IEnumerator Rise(int amount, float range, float speed, float ScaleFactor, float lifetime, float ThreshHold)
    {
        for (; ;)
        {
            for (int i = 0; i < amount; i++)
            {
                try
                {
                    //rise particle by the generated random speed about  
                    Particles[i].transform.Translate(0, Speeds[i], 0);

                    //decrease scalle by generated scale amount
                    Particles[i].transform.localScale -= new Vector3(Scales[i], Scales[i], Scales[i]);
                    //if particle size is ever smaller than threshold destroy the object
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

    IEnumerator Kill(int amount, float range, float speed, float ScaleFactor, float lifetime, float ThreshHold)
    {
        float time = 0;
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
