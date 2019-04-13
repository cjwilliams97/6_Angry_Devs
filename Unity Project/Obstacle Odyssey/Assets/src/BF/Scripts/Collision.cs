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
    // bind audio
    AudioHandler audioHandler;
    private float damage;

    // Start is called before the first frame update
    public virtual void Start()
    {
        audioHandler = AudioHandler.instance;
        damage = 25; // defaults to 25 damage
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Scripts").SendMessage("HealthChangeDamage", damage);
        audioHandler.PlayAudio("barrel impact");
        Destroy(gameObject);
    }
}
