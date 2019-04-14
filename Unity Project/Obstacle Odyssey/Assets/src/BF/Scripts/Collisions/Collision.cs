/* Brandon Foss
 * This script acts like a base class for collision scripts that provides
 * a default collision which can be modified through inheritance classes.
 * It defaults to the impact of a barrel
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public AudioHandler audioHandler; // bind audio
    public float damage; // intitializes a damage value to be inherited and changed

    // Start is called before the first frame update
    void Start()
    {
        DoInitialization(); // initializes values   
    }

    public void DoInitialization()
    {
        audioHandler = AudioHandler.instance; // creates instance of audio handler
        damage = 25; // defaults to 25 damage
        Debug.Log("Initialized Collision");
    }

    // This method will initialize a collision to a standard collision that could be overriden
    public virtual void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Scripts").SendMessage("HealthChangeDamage", damage); // calls damage script
        audioHandler.PlayAudio("barrel impact"); // calls audio script to play barrel sounds
        Destroy(gameObject); // removes the game object
    }
}
