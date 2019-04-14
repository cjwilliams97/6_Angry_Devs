using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * The generateSmoke class allows for the attached gameobjet to generate a smoke particle system
 * The smoke particles are fbx models and textures stored under the Resources folder to allow
 * for the usage of the Resources.Load function. Smoke can also be generated on an interval
 * using the repeating version of the smoke generating function.
 */ 


public class GenerateSmoke : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject[] Particles;
    public GameObject PARENT;
    private float[] Speeds;
    private float[] Scales;
    private Texture Smoke_texture1;
    private Texture Smoke_texture2;
   
    void Start()
    {
        SmokeySmokeRepeating();
        return;
    }

    public void SmokeySmoke()
    {
        Debug.Log("SmokeySmoke running");
        int amount = 150;   //number of particles to be spawned
        float range = 2f; //distance from origin when generating particles
        float speed = 1.5f * 0.1f; //upper limit for rising speed
        float ScaleFactor = 2f; //affects how quickly things shrink (high number = faster shrinking)
        float lifetime = 5f;    //upper limit of how long a particle can live for 
        float ThreshHold = .1f;   //minimum size a particle can be before it get auto destroyed
        SmokeySmoke(amount, range, speed, ScaleFactor, lifetime, ThreshHold);
    }

    private void SmokeySmokeRepeating()
    {
        InvokeRepeating("SmokeySmoke", 1.0f, 4f);
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
            Speeds[i] = Random.Range(speed / 32, speed / 2);
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
        {
            yield break;
        }
        for (int i = 0; i < amount; i++)
        {
            //generates an equal distribution of medium and smoke particles
            if(i % 2 == 0)
            {
                try
                {
                  Particles[i] = Instantiate(Resources.Load("JD/Smoke/smoke_medium", typeof(GameObject)), 
                      PARENT.transform.position,
                      PARENT.transform.rotation,
                      PARENT.transform) as GameObject;
                }
                catch
                {
                    Particles[i].transform.position = PARENT.transform.position;
                    Particles[i].transform.rotation = PARENT.transform.rotation;
                    Particles[i].transform.SetParent(PARENT.transform);
                    Debug.Log("Instantiation of particle failed");
                }
            }
            else
            {
                try
                {
                    Particles[i] = Instantiate(Resources.Load("JD/Smoke/smoke_small", typeof(GameObject)),
                        PARENT.transform.position,
                        PARENT.transform.rotation,
                        PARENT.transform) as GameObject;
                }
                catch
                {
                    Particles[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Particles[i].transform.position = PARENT.transform.position;
                    Particles[i].transform.rotation = PARENT.transform.rotation;
                    Particles[i].transform.SetParent(PARENT.transform);
                    Debug.Log("Instantiation of particle failed");
                }
            }
 
            //assigns textures half and half to particles
            if (i % 2 == 0)
            {
                Particles[i].gameObject.GetComponent<Renderer>().material.mainTexture = Smoke_texture1;
            }
               
            else
            {
                Particles[i].gameObject.GetComponent<Renderer>().material.mainTexture = Smoke_texture2;
            }

           
            time += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    private IEnumerator Rise(int amount, float range, float speed, float ScaleFactor, float lifetime, float ThreshHold)
    {
        float time = 0;
        if (time >= lifetime * 2)
        {
            yield break;
        }
          
        while (time <= lifetime)
        {
            time += Time.deltaTime;
            for (int i = 0; i < amount; i++)
            {
                try
                {
                    //rise particle by the generated random speed about  
                    Particles[i].transform.Translate(Speeds[i % 10], Speeds[i], Speeds[i % 10]);
                     //decrease scale by generated scale amount
                     Particles[i].transform.localScale += new Vector3(-Scales[i], -Scales[i], -Scales[i]);
                    //if particle size is ever smaller than threshold destroy the object
                    if (Particles[i].transform.localScale.x <= ThreshHold)
                        Destroy(Particles[i]);
                }
                catch
                {  }
            }
            yield return null;
        }
        yield break;
    }

    private IEnumerator Kill(int amount, float range, float speed, float ScaleFactor, float lifetime, float ThreshHold)
    {
        float time = 0;
        if (time >= lifetime * 2)
        {
            yield break;
        }
           
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
        yield break;
    }
}
