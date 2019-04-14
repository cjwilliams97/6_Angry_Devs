/* Brandon Foss
 * HUDManager script implementing singleton pattern to ensure that only one instance
 * of the HUD and delete duplicates
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get; private set; }

    public int Value;

    private void Awake()
    {
        if(Instance == null) // if nothing is stored in Instance property
        {
            Instance = this; // set to contain this particular instance
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject); // otherwise destroys duplicate instances and gameObjects
        }
    }
}
