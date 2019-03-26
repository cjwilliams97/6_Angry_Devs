using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleCollision : MonoBehaviour
{
    // bind audio
    AudioHandler audioHandler;
    void Start() {
        audioHandler = AudioHandler.instance;
    }

    private float damage = 50;

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Scripts").SendMessage("HealthChangeDamage", damage);
        audioHandler.PlayAudio("orca impact");
        Destroy(gameObject);
    }
}

