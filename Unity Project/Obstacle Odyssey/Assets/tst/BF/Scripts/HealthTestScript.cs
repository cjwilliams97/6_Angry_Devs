/* Brandon Foss
 * This script will run a stress test on the health scrip to have it hit 4000 barrels
 * that will each do 1 damage. The ship is at 400 health so it works if it hits all 
 * barrels and fails otherwise indicating bad physics detection at high numbers.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTestScript : MonoBehaviour
{
    public Text healthText;
    public Text test1Text;
    private float healthStart; // starting ship health
    private static float maxHealth = 4000; // creates max ship health
    private float oldHealth;
    private float updatedHealth;
    private bool passed = false;
    public float timer = 15;
    

    // this will initialize the health hud to the max health value
    void Start()
    {
        healthStart = maxHealth; // intializes starting to max health
        oldHealth = healthStart; // sets old health to starting health
        string newHealth = healthStart.ToString(); // converts the float values to a string
        healthText.text = "Health: " + newHealth + " / " + maxHealth; // alters the text that is displayed to the screen
        test1Text.text = "Test 1 - Health Decreases on Each Hit - Pending";
        passed = false;
        timer = 15;
        
    }

    // this can be called to decrease health when damage is applied from obstacle
    public void HealthChangeDamage(float healthChange)
    {
        updatedHealth = oldHealth - healthChange; // figures out new health value

        if (updatedHealth <= 0) // checks to make sure health doesn't go over max
        {
            updatedHealth = 0;
            healthText.fontSize = 65;
            healthText.color = Color.red;
            healthText.text = ("You Died!!"); // alters the text that is displayed to the screen
            test1Text.color = Color.green;
            passed = true;
            test1Text.text = "Test 1 - Health Decreases on Each Hit - Passed";

            return;
        }

        string newHealth = (updatedHealth).ToString(); // converts the float values to a string
        oldHealth = oldHealth - healthChange; // changes oldHealth to updated version after being used
        healthText.text = "Health: " + newHealth + " / " + maxHealth; // alters the text that is displayed to the screen
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 1)
        {
            if(!passed)
            {
                test1Text.color = Color.red;
                test1Text.text = "Test 1 - Health Decreases on Each Hit - Failed";
            }
        }
    }

    // this can be called to increase health when a bonus is picked up
    public void HealthChangeBonus(float healthChange)
    {
        updatedHealth = oldHealth - healthChange; // figures out new health value

        if (updatedHealth > maxHealth) // checks to make sure health doesn't go over max
        {
            updatedHealth = maxHealth;
        }

        string newHealth = (updatedHealth).ToString(); // converts the float values to a string
        oldHealth = oldHealth - healthChange; // changes oldHealth to updated version after being used
        healthText.text = "Health: " + newHealth + " / " + maxHealth; // alters the text that is displayed to the screen
    }
}
