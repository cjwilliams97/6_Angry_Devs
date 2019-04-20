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
    public SFXHandler sfxHandler; // bind audio
    public float damage; // intitializes a damage value to be inherited and changed
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        DoInitialization(); // initializes values   
    }

    public void DoInitialization()
    {
        sfxHandler = SFXHandler.instance; // creates instance of audio handler
        damage = 25; // defaults to 25 damage
        active = true;
        //Debug.Log("Initialized Collision");
    }

    // This method will initialize a collision to a standard collision that could be overriden
    public virtual void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            GameObject.Find("Scripts").SendMessage("HealthChangeDamage", damage); // calls damage script
            sfxHandler.PlayAudio("barrel impact"); // calls audio script to play barrel sounds
            Destroy(gameObject); // removes the game object
            StartCoroutine("DisableScript"); // disables script for 3 seconds to avoid rapid collisions
        }
    }

    // calling this will alow me to disable the script for 4 seconds to avoid rapid collision with 1 object
    public IEnumerator DisableScript()
    {
        active = false;
        yield return new WaitForSeconds(4f);
        active = true;
    }
   
}
