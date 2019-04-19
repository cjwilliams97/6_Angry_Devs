using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Singelton_Boat : MonoBehaviour
{
    //Implementing singleton patter, which makes sure only one of these classes exsits

    public static Singelton_Boat Instance { get; private set; }

    //Awake is called only once during the lifetime of the script instance. 
    //And is called after all objects are initialized so you can safely speak to other objects
    private void Awake()
    {
        if (Instance == null) // No instance has yet been made
        {
            Instance = this; // This is the first instance
            DontDestroyOnLoad(gameObject);
        }

        else // Get rid of all extras
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
