/* Brandon Foss
 * This script inherits from the base collision class and modifies
 * the OnTriggerEnter method to perform as intended for a rock impact
 * to only take apply 1 health damage
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelCollisionTest : Collision
{
    void Start()
    {
        base.DoInitialization(); // calls base class initialization
        damage = 1; // changes damage value after initialization
    }

    // This method will initialize a collision to a standard collision that could be overriden
    public virtual void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            GameObject.Find("Scripts").SendMessage("HealthChangeDamage", damage); // calls damage script
            //audioHandler.PlayAudio("barrel impact"); // calls audio script to play barrel sounds
            Destroy(gameObject); // removes the game object
            StartCoroutine("DisableScript"); // disables script for 3 seconds to avoid rapid collisions
        }
    }
}
