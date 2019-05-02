using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallCollision : Collision
{
  
    void Start()
    {
        base.DoInitialization(); // calls base class initialization
        damage = 75; // changes damage value after initialization
    }

    // ovverides method to form to rock collisions
    public override void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            GameObject.Find("Scripts").SendMessage("HealthChangeDamage", damage); // calls damage script
            sfxHandler.PlayAudio("explosion echo"); // calls audio script to play rock sounds
            base.StartCoroutine("DisableScript"); // disables script for 3 seconds to avoid rapid collisions
        }
    }
}
