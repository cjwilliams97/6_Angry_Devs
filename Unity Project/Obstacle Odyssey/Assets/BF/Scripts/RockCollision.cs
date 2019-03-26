using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour
{
    // bind audio
    AudioHandler audioHandler;
    void Start() 
    {
        audioHandler = AudioHandler.instance;
    }

    private float damage = 25;

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Scripts").SendMessage("HealthChangeDamage", damage);
        audioHandler.PlayAudio("rock impact");
        Destroy(gameObject);
    }
}

