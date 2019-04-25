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
    public Text healthChangeText;
    public Text healthChangeText2;
    private float healthStart; // starting ship health
    private static float maxHealth; // creates max ship health
    private float oldHealth;
    private float updatedHealth;
    private bool flag = false;
    private bool flag2 = false; // used to check if multiple health changes are registered
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
        healthChangeText.text = ""; // will initialize this text to nothing
        healthChangeText2.text = ""; // will initialize this text to nothing
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
                healthChangeText.text = ""; // resets all text
                healthChangeText2.text = ""; // resets all text
                return;
            }

            StartCoroutine(DisplayHealthChange(healthChange, true)); // gives damage and indicates it is damage

            string newHealth = (updatedHealth).ToString(); // converts the float values to a string
            oldHealth = updatedHealth; // changes oldHealth to updated version after being used
            healthText.text = "Health: " + newHealth + " / " + maxHealth; // alters the text that is displayed to the screen
        }
    }

    // this can be called to increase health when a bonus is picked up
    public virtual void HealthChangeBonus(float healthChange)
    {
        updatedHealth = oldHealth + healthChange; // figures out new health value

        if(updatedHealth > maxHealth) // checks to make sure health doesn't go over max
        {
            updatedHealth = maxHealth;
            StartCoroutine(MaxedHealth());
        }

        else
        {
            StartCoroutine(DisplayHealthChange(healthChange, false));
            string newHealth = (updatedHealth).ToString(); // converts the float values to a string
            healthText.text = "Health: " + newHealth + " / " + maxHealth; // alters the text that is displayed to the screen 
        }

        oldHealth = updatedHealth; // changes oldHealth to updated version after being used     
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

    // will display new message if health is maxed and new health is added
    IEnumerator MaxedHealth()
    {
        healthText.text = "Health Maxed!";
        yield return new WaitForSeconds(2f);
        string newHealth = (updatedHealth).ToString(); // converts the float values to a string
        healthText.text = "Health: " + newHealth + " / " + maxHealth; // alters the text that is displayed to the screen

    }

    // will display new text that shows health change
    IEnumerator DisplayHealthChange(float healthChange, bool decrease)
    {
        if (decrease) // if the change is damage
        {
            if (flag2 == false) // runs on first damage
            {
                flag2 = true;
                healthChangeText.color = new Color32(224, 36, 20, 255); // changes color to redish
                healthChangeText.text = "-" + healthChange;
                yield return new WaitForSeconds(2f); // will wait for 2 seconds with new text display        
                healthChangeText.text = ""; // will reset to no text
                flag2 = false; // indicates initial display is done
            }

            else // runs if first text is in the process of displaying
            {
                healthChangeText2.color = new Color32(224, 36, 20, 255); // changes color to redish
                healthChangeText2.text = "-" + healthChange;
                yield return new WaitForSeconds(2f); // will wait for 2 seconds with new text display        
                healthChangeText2.text = ""; // will reset to no text
            }
        }

        else
        {
            if (flag2 == false) // runs on first damage
            {
                flag2 = true;
                healthChangeText.color = new Color32(46, 205, 42, 255); // changes color to greenish
                healthChangeText.text = "+" + healthChange;
                yield return new WaitForSeconds(2f); // will wait for 2 seconds with new text display        
                healthChangeText.text = ""; // will reset to no text
                flag2 = false; // indicates initial display is done
            }

            else // runs if first text is in the process of displaying
            {
                healthChangeText2.color = new Color32(46, 205, 42, 255); // changes color to greenish
                healthChangeText2.text = "+" + healthChange;
                yield return new WaitForSeconds(2f); // will wait for 2 seconds with new text display        
                healthChangeText2.text = ""; // will reset to no text
            }
        }
    }
}

    
    
