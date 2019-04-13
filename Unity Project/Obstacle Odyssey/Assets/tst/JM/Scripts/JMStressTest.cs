using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JMStressTest : MonoBehaviour
{
    //Declarations
    //private IEnumerator coroutine;
    public Text speedText;
    public float count = 0;
    public float i = .025f;
    public float delta = 50.5f;
    public float speed = .25f;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(coroutine);
        startPos = transform.position;
        speedText.text = "Whale Speed: " + speed.ToString();
        //countText.text = "Number of Boats Sunk: " + count.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        speed += i * Time.deltaTime;
        speedText.text = "Whale Speed: " + speed.ToString();
        Vector3 v = startPos;
        v.z += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
