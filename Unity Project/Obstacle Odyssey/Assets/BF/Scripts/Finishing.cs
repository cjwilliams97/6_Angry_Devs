using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishing : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("caravel").SendMessage("Finnish"); 
    }
}
