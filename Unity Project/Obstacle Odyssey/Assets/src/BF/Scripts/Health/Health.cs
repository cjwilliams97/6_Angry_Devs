/* Brandon Foss
 * This script will track the health of the caravel and any changes to it.
 * It displays the current health to the hud display and has functions that
 * can be used to access health values.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healthText;
    private float healthStart; // starting ship health
    private static float maxHealth; // creates max ship health
    private float oldHealth;
    private float updatedHealth;
    private bool flag = false;
    private bool accessed = false; // will check to make sure method is accessed

    // this will initialize the health hud to the max health value
    void Start()
    {
        if (!accessed)
        {
            healthStart = 100;
            maxHealth = 100;
            updatedHealth = maxHealth;
        }
        else
        {
            healthStart = maxHealth;
            updatedHealth = maxHealth;
        }

        oldHealth = healthStart; // sets old health to starting health
        string newHealth = healthStart.ToString(); // converts the float values to a string
        healthText.text = "Health: " + newHealth + " / " + maxHealth; // alters the text that is displayed to the screen
    }

    // this can be called to decrease health when damage is applied from obstacle
    public virtual void HealthChangeDamage(float healthChange)
    {
        if (flag == false)
        {
            updatedHealth = oldHealth - healthChange; // figures out new health value

            if (updatedHealth <= 0) // checks to make sure health doesn't go over max
            {
                if(flag == false)
                {
                    flag = true;
                }

                updatedHealth = 0; 
                oldHealth = 0;
                healthText.color = Color.red;
                healthText.text = ("You Died!!"); // alters the text that is displayed to the screen
                return;
            }

            string newHealth = (updatedHealth).ToString(); // converts the float values to a string
            oldHealth = oldHealth - healthChange; // changes oldHealth to updated version after being used
            healthText.text = "Health: " + newHealth + " / " + maxHealth; // alters the text that is displayed to the screen
        }
    }

    // this can be called to increase health when a bonus is picked up
    public virtual void HealthChangeBonus(float healthChange)
    {
        updatedHealth = oldHealth - healthChange; // figures out new health value

        if(updatedHealth > maxHealth) // checks to make sure health doesn't go over max
        {
            updatedHealth = maxHealth;
        }

        string newHealth = (updatedHealth).ToString(); // converts the float values to a string
        oldHealth = oldHealth - healthChange; // changes oldHealth to updated version after being used
        healthText.text = "Health: " + newHealth + " / " + maxHealth; // alters the text that is displayed to the screen
    }

    // this can be called to change the MaxHealth value
    public void MaxHealthChange(float newMax) 
    {
        if (newMax > 100)
        {
            maxHealth = newMax;
            Debug.Log("New Health Total: " + newMax);
        }

        else maxHealth = 100;

        accessed = true;
    }

    // this will return the current health value
    public float ReturnHealth()
    {
        return updatedHealth;
    }
}

    
    
