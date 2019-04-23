/* Brandon Foss
 * This script inherits from the base collision class and modifies
 * the OnTriggerEnter method to perform as intended for a question mark impact.
 * It will perform a random action based on chance.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMarkCollision : Collision
{
    private int randomNumber = 0; // used later to randomize result
    private float bonusHealth = 25;

    void Start()
    {
        base.DoInitialization(); // calls base class initialization
        randomNumber = 0;
        bonusHealth = 25;
    }

    // ovverides method to form to question mark collisions
    public override void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            randomNumber = Random.Range(0, 101); // returns random number between 0 and 100
            Debug.Log("Random number is: " + randomNumber);

            switch (randomNumber)
            {
                case int n when (n >= 0 && n < 51):
                    Debug.Log("made it to first case");
                    GameObject.Find("Scripts").SendMessage("HealthChangeDamage", damage);
                    break;

                case int n when (n >= 51 && n < 101):
                    Debug.Log("made it to second case");
                    GameObject.Find("Scripts").SendMessage("HealthChangeBonus", bonusHealth);
                    break;
            }
                    
            Destroy(gameObject); // removes the game object
        }
    }
}

