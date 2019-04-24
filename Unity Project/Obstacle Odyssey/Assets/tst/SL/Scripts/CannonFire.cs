using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    private KeyCode Fire = KeyCode.Q;
    public GameObject CannonBall;

    private Vector3 CannonFirePointLocation;
    public GameObject CannonFirePoint;
    public Material CannonballMat;
    private Rigidbody rigid;
    private GameObject Ball;
    public float Power;
    public float FireTime;
    public GameObject ExplosionObj;
    private GameObject Explosion;
    private bool IsInFiringCooldown;


    void Start()
    {
        Power = 1000f;
        FireTime = 1.0f;
        IsInFiringCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsInFiringCooldown == false)
        {
            if (Input.GetKeyDown(Fire))
            {

                FireCannon(Power);


            }
        }       
    }


    /*
     * Requires a float for power of shot I Recommend 1000.0f for a medium shot
     * Destroys explosion gameobject after 5s
     * Destorys Ball after 20s
     * 
     */ 
    public void FireCannon( float power)
    {
        Ball = (GameObject)Instantiate(CannonBall);
        Ball.transform.parent = CannonFirePoint.transform;
        Ball.transform.position = CannonFirePoint.transform.position;
        Ball.transform.eulerAngles = CannonFirePoint.transform.eulerAngles;
        Ball.AddComponent<Rigidbody>();
        rigid = Ball.GetComponent<Rigidbody>();
        rigid.AddRelativeForce(Power, 0.0f, 0.0f);
        Explosion = (GameObject)Instantiate(ExplosionObj);
        Explosion.transform.parent = CannonFirePoint.transform;
        Explosion.transform.position = CannonFirePoint.transform.position;
        Explosion.transform.eulerAngles = CannonFirePoint.transform.eulerAngles;
        Explosion.transform.Rotate(0.0f, 0.0f, 90.0f);
        Explosion.transform.localScale = new Vector3(.001f, .001f, .001f);
        Destroy(Explosion, 5.0f);
        Destroy(Ball, 15.0f);
        
        
    }

}