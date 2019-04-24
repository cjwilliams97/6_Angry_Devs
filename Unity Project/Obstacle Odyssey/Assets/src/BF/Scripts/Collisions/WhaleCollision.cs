/* Brandon Foss
 * This script inherits from the base collision class and modifies
 * the OnTriggerEnter method to perform as intended for a whale impact
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleCollision : Collision
{
    void Start()
    {
        base.DoInitialization(); // calls base class initialization
        damage = 50; // changes damage value after initialization
    }

    // ovverides method to form to orca collisions
    public override void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            GameObject.Find("Scripts").SendMessage("HealthChangeDamage", damage); // calls damage script
            sfxHandler.PlayAudio("orca impact"); // calls audio script to play orca sounds
            base.StartCoroutine("DisableScript"); // disables script for 3 seconds to avoid rapid collisions
        }
    }
}

