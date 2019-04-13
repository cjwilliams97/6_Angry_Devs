using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrelManager : MonoBehaviour
{
    public GameObject barrel;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public static int barrel_count = 0; //keeps track of # of barrels.
    public Text display_text;


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        barrel_count = 0;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Update()
    {

        display_text.text = string.Concat("Barrel Count: ", barrel_count.ToString());
        //display_text.text = barrel_count.ToString();
     
    }
    void Spawn()
    {
        barrel_count = barrel_count + 1;
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(barrel, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}