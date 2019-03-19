using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Scripts").SendMessage("GameFinish");
    }
}
