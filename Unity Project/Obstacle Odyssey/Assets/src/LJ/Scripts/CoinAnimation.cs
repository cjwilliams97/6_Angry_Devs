using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    private float speed = 30f;

    void Start()
    {
        // randomize initial orientation
        transform.Rotate(Vector3.forward, Random.Range(0, 90));
    }

    void Update()
    {
        // rotate the coin
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
