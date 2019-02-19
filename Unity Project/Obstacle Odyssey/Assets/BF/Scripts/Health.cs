using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healthText;
    private float healthStart; // starting ship health
    private static float maxHealth = 100; // creates max ship health
    private float oldHealth;
    private float updatedHealth;
    
    // this will initialize the health hud to the max health value
    void Start()
    {
        healthStart = maxHealth; // intializes starting to max health
        oldHealth = healthStart; // sets old health to starting health
        string newHealth = healthStart.ToString(); // converts the float values to a string
        healthText.text = newHealth + " / " + maxHealth; // alters the text that is displayed to the screen
    }

    // this can be called to decrease health when damage is applied from obstacle
    public void HealthChangeDamage(float healthChange)
    {
        updatedHealth = oldHealth - healthChange; // figures out new health value

        if (updatedHealth <= 0) // checks to make sure health doesn't go over max
        {
            updatedHealth = 0;
            healthText.text = ("You Dead!"); // alters the text that is displayed to the screen
            return;
        }

        string newHealth = (updatedHealth).ToString(); // converts the float values to a string
        oldHealth = oldHealth - healthChange; // changes oldHealth to updated version after being used
        healthText.text = newHealth + " / " + maxHealth; // alters the text that is displayed to the screen
    }

    // this can be called to increase health when a bonus is picked up
    public void HealthChangeBonus(float healthChange)
    {
        updatedHealth = oldHealth - healthChange; // figures out new health value

        if(updatedHealth > maxHealth) // checks to make sure health doesn't go over max
        {
            updatedHealth = maxHealth;
        }

        string newHealth = (updatedHealth).ToString(); // converts the float values to a string
        oldHealth = oldHealth - healthChange; // changes oldHealth to updated version after being used
        healthText.text = newHealth + " / " + maxHealth; // alters the text that is displayed to the screen
    }
}
