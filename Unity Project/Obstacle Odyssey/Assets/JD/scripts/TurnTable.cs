using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurnTable : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider SpeedSlider;
    void Start()
    {
        if (SpeedSlider == null)
            Debug.Log("Speed Slider not attached!");       
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, Time.deltaTime * (SpeedSlider.value * 18.0f));
    }
}
