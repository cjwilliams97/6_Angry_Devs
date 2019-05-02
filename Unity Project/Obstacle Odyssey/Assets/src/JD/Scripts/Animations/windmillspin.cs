using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windmillspin : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField]
    float speed = 16f;
    void FixedUpdate()
    {
        this.transform.Rotate(0, speed * Time.deltaTime, 0, Space.Self);
    }
}
