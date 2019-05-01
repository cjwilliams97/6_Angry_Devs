using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFans : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rigid;
    public float FanSpeed;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rigid.transform.Rotate(0, 0, FanSpeed, Space.Self);
    }
}
