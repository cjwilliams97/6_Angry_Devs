/* Brandon Foss
 * This script provides a health script that can be applied to the whale that takes damage
 * from the ship when it collides. It can later be modified to be hit by a cannon as well.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhaleHealth : Health
{
    public Text whaleHealthText;
    private float healthStart; // starting whale health
    private static float maxHealth = 50; // creates max ship health
    private float oldHealth;
    private float updatedHealth;
    private bool flag = false;

    // this will initialize the health of the whale
    void Start()
    {
        healthStart = maxHealth; // intializes starting to max health
        oldHealth = healthStart; // sets old health to starting health
        string newHealth = healthStart.ToString(); // converts the float values to a string
        whaleHealthText.text = "Health: " + newHealth + " / " + maxHealth; // alters the text that is displayed to the screen
    }

    // this can be called to decrease health when damage is applied from obstacle
    public override void HealthChangeDamage(float healthChange)
    {
        if (flag == false)
        {
            updatedHealth = oldHealth - healthChange; // figures out new health value

            if (updatedHealth <= 0) // checks to make sure health doesn't go over max
            {
                if (flag == false)
                {
                    flag = true;
                }

                updatedHealth = 0;
                oldHealth = 0; 
                whaleHealthText.color = Color.red;
                whaleHealthText.text = ("You Killed The Whale!!"); // alters the text that is displayed to the screen
                Destroy(gameObject); // despawns whale when dead
                return;
            }

            string newHealth = (updatedHealth).ToString(); // converts the float values to a string
            oldHealth = oldHealth - healthChange; // changes oldHealth to updated version after being used
            whaleHealthText.text = "Health: " + newHealth + " / " + maxHealth; // alters the text that is displayed to the screen
        }
    }
}
