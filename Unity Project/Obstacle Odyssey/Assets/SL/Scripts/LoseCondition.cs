using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoseCondition : MonoBehaviour
{
    public Rigidbody rigid;
    private float health;
    public GameObject reference;
    private bool FirstFrame = true;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        FirstFrame = true;
        coroutine = Wait(2.0f);
        rigid = GetComponent<Rigidbody>();
        rigid.GetComponent<BoatProbes>()._forceMultiplier = 16.0f;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (FirstFrame == true)
        {
            StartCoroutine(coroutine);
            Debug.Log("Coroutine Started");
        }

        if (FirstFrame == false) 
        {
            health = reference.GetComponent<Health>().ReturnHealth();
            Debug.Log("Returned health is :" + health);
            if (health <= 0) //test for health <= 0
            {
                Debug.Log("Player has lost");
                SinkShip();
            }
        }

        
    }
    public bool SinkShip()
    {
        Debug.Log("Sinking Ship");
        rigid.GetComponent<BoatProbes>()._forceMultiplier = .85f;
        rigid.GetComponent<BoatProbes>()._playerControlled = false;
        return true ;
    }
    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);

        FirstFrame = false;
    }
}
