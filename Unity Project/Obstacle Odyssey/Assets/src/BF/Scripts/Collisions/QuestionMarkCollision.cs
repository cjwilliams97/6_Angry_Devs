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
    public GameObject coinPrefab; // lets me modify what to spawn for prefabs
    private bool flag1 = false;

    void Start()
    {
        base.DoInitialization(); // calls base class initialization
        randomNumber = 0;
        bonusHealth = 25;
        flag1 = false;
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
                case int n when (n >= 0 && n <= 33): // this case will decrease the health of the ship
                    Debug.Log("made it to first case");
                    GameObject.Find("Scripts").SendMessage("HealthChangeDamage", damage);
                    break;

                case int n when (n >= 0 && n <= 100): // this case will add health to the ship
                    Debug.Log("made it to second case");
                    GameObject.Find("Scripts").SendMessage("HealthChangeBonus", bonusHealth);
                    break;

                case int n when (n > 33 && n <= 66): // this case will spawn coins in front of the boat
                    Debug.Log("made it to third case");
                    float valueX = GameObject.Find("caravel").transform.position.x; // obatins ship x, y, z coordinates
                    float valueY = GameObject.Find("caravel").transform.position.y;
                    float valueZ = GameObject.Find("caravel").transform.position.z;
                    Debug.Log("caravel location: " + valueX + ", " + valueY + ", " + valueZ);
                    valueX -= 10; // offsets coins for easier visibility
                    valueY += 4f; // keeps coins lower to ground
                    valueZ += 30; // starts coins in front of boat
                    for (int i = 0; i < 5; i++) // this will place the coins in a little bunch in front of the ship
                    {
                        if (flag1 == false)
                        {
                            valueZ += 5;
                            valueX -= 2;
                            flag1 = true;
                            Instantiate(coinPrefab, new Vector3(valueX, valueY, valueZ), Quaternion.Euler(-90, 0, 0));
                        }

                        else
                        {
                            valueZ += 3;
                            valueX += 2;
                            flag1 = false;
                            Instantiate(coinPrefab, new Vector3(valueX, valueY, valueZ), Quaternion.Euler(-90, 0, 0));
                        }
                    }
                    break;
            }
                    
            Destroy(gameObject); // removes the game object
        }
    }
}

