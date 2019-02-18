using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private KeyCode Port = KeyCode.A;
    private KeyCode Starboard = KeyCode.D;
    public float Bank_Scale = 8.0f;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }


    private void Update()
    {
        if (Input.GetKey(Port)){
            transform.Rotate(0.0f, -Time.deltaTime * Bank_Scale, 0.0f, Space.Self);
        }
        if (Input.GetKey(Starboard))
        {
            transform.Rotate(0.0f, Time.deltaTime * Bank_Scale, 0.0f, Space.Self);
        }
        transform.position = player.transform.position + offset;
    }
    void LateUpdate()
    {
        
        //subscribe to pewdiepie
    }
}
