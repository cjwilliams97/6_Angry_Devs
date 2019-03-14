using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverTheTopCamera : MonoBehaviour
{
    public GameObject caravel = null;
    // Start is called before the first frame update
    void Start()
    {
        //caravel = caravel.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = caravel.transform.position;
        transform.position = new Vector3(caravel.transform.position.x, 550f, caravel.transform.position.z);
    }
}
