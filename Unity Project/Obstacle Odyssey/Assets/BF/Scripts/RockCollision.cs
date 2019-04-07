using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : Collision
{
    // bind audio
    AudioHandler audioHandler;
    public Health health; // needed to call script later
    private float damage;

    public override void Start() 
    {
        base.Start();
        damage = 25;
        audioHandler = AudioHandler.instance;
    }


    public override void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Scripts").SendMessage("HealthChangeDamage", damage);
        audioHandler.PlayAudio("rock impact");
    }
}

