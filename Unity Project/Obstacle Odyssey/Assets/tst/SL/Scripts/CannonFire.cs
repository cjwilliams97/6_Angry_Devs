using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    private KeyCode Fire = KeyCode.Q;
    public GameObject CannonBall;

    private Vector3 CannonFirePointLocation;
    public GameObject CannonFirePoint;
    public Texture CannonballMat;
    private IEnumerator coroutine;
    private Rigidbody rigid;
    private GameObject Ball;
    public float Power;
    public float FireTime;
    public GameObject ExplosionObj;
    private GameObject Explosion;
    private bool IsInFiringCooldown;
    private bool test;
    public int predictionStepsPerFrame = 6;
    public Vector3 BallVelocity;
    






    void Start()
    {
        
       // Power = 1000f;
        //FireTime = 1f;
        IsInFiringCooldown = false;
        test = false;
        FireCannonTimed(Power, FireTime);
       
        //float PowerToVelocityScale = 53.708f;

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (IsInFiringCooldown == false)
        {
            if (Input.GetKeyDown(Fire))
            {
                test = true;
                FireCannon(Power);
                


            }
          
        }*/
        
        /*
        Vector3 point1 = this.transform.position;
        float stepSize = 1.0f / predictionStepsPerFrame;
        for (float step = 0; step < 1; step += stepSize)
        {
            BallVelocity += Physics.gravity * stepSize * Time.deltaTime;
            Vector3 point2 = point1 + BallVelocity * stepSize * Time.deltaTime;

            Ray ray = new Ray(point1, point2 - point1);
            if (Physics.Raycast(ray, (point2 - point1).magnitude))
            {
                Debug.Log("Hit");
            }

        }*/
    }


    /*
     * Requires a float for power of shot I Recommend 1000.0f for a medium shot
     * Destroys explosion gameobject after 2s
     * Destorys Ball after 60s
     * 
     */ 
    public void FireCannon( float power)
    {
        
        Ball = (GameObject)Instantiate(CannonBall);
        Ball.transform.parent = CannonFirePoint.transform;
        Ball.transform.position = CannonFirePoint.transform.position;
        Ball.transform.eulerAngles = CannonFirePoint.transform.eulerAngles;
        Ball.AddComponent<Rigidbody>();
        Ball.AddComponent<BoxCollider>();
        Ball.GetComponent<Renderer>().material.mainTexture = CannonballMat;
        rigid = Ball.GetComponent<Rigidbody>();
        rigid.AddRelativeForce(Power, 0.0f, 0.0f);
        AngularTorqueCalculation(rigid);
        Explosion = (GameObject)Instantiate(ExplosionObj);
        Explosion.transform.parent = CannonFirePoint.transform;
        Explosion.transform.position = CannonFirePoint.transform.position;
        Explosion.transform.eulerAngles = CannonFirePoint.transform.eulerAngles;
        Explosion.transform.Rotate(0.0f, 0.0f, 90.0f);
        Explosion.transform.localScale = new Vector3(.001f, .001f, .001f);
        Destroy(Explosion, 2.0f);
        Destroy(Ball, 60.0f);

        
        
    }
    /*
     * Requires a float for power of shot I Recommend 1000.0f for a medium shot
     * Also Requires a float time, which is the time between shots in Seconds
     * Calling this once will start
     * Destroys explosion gameobject after 2s
     * Destorys Ball after 60s
     * 
     */
    public void FireCannonTimed(float power, float time)
    {   
      
        coroutine = FireTimer(time);
        IsInFiringCooldown = true;
        Power = power;
        //Debug.Log("Firing cooldown is.. " + IsInFiringCooldown);
        Ball = (GameObject)Instantiate(CannonBall);
        Ball.transform.parent = CannonFirePoint.transform;
        Ball.transform.position = CannonFirePoint.transform.position;
        Ball.transform.eulerAngles = CannonFirePoint.transform.eulerAngles;
        Ball.AddComponent<Rigidbody>();
        Ball.AddComponent<BoxCollider>();
        Ball.GetComponent<Renderer>().material.mainTexture = CannonballMat;
        rigid = Ball.GetComponent<Rigidbody>();
        rigid.AddRelativeForce(Power*Vector3.forward);
        AngularTorqueCalculation(rigid);
        Explosion = (GameObject)Instantiate(ExplosionObj);
        Explosion.transform.parent = CannonFirePoint.transform;
        Explosion.transform.position = CannonFirePoint.transform.position;
        Explosion.transform.eulerAngles = CannonFirePoint.transform.eulerAngles;
        Explosion.transform.Rotate(0.0f, 0.0f, 90.0f);
        Explosion.transform.localScale = new Vector3(.001f, .001f, .001f);
        StartCoroutine(coroutine);
        Destroy(Explosion, 2.0f);
        Destroy(Ball, 60.0f);


        

    }
    private void AngularTorqueCalculation(Rigidbody rigid)
    {
        bool XNeg = false;
        bool YNeg = false;
        bool ZNeg = false;
        double RandomNum = Random.value;
        if (RandomNum < .33)
        {
            XNeg = true;
        }
        if (RandomNum > .67)
        {
            YNeg = true;
        }
        if (RandomNum >= .33 && RandomNum <= .67)
        {
            ZNeg = true;
        }
        if (XNeg == true)
        {
            rigid.AddTorque(-1000.0f * Random.value, 1000f * Random.value, 1000f * Random.value);
        }
        if (YNeg == true)
        {
            rigid.AddTorque(1000.0f * Random.value, -1000f * Random.value, 1000f * Random.value);
        }
        if (ZNeg == true)
        {
            rigid.AddTorque(1000.0f * Random.value, 1000f * Random.value, -1000f * Random.value);
        }
        
    }
    private IEnumerator FireTimer(float time)
    {
        //Debug.Log("Fire Time is .." + time);
        yield return new WaitForSeconds(time);
        IsInFiringCooldown = false;
        //Debug.Log("Firing cooldown is.. " + IsInFiringCooldown);
        FireCannonTimed(Power, FireTime);
    }
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 point1 = this.transform.position;
        Vector3 PredictedBallVelocity = BallVelocity;
        float stepSize = .1f;
        for (float step = 0; step < 1; step += stepSize)
        {
            PredictedBallVelocity += Physics.gravity * stepSize * Time.deltaTime;
            Vector3 point2 = point1 + PredictedBallVelocity * stepSize;
            Gizmos.DrawLine(point1, point2);
            point1 = point2;
        }

    }
    */
}