using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Test template for a Caravel maker script
 * 
 *  utilizing the wrapper method, attributes or perks can be added to visually update the ship 
 */

public class Caravel_Maker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Caravel maker here: trying stuff");
        /*
        //Using the wrapper method to instantiate whole caravel and all included attributes
        CaravelInterface MahShip = new Caravel_Plating(new Caravel_Lantern(new PlainShip()));
        Debug.Log("Description:" + MahShip.getDescription());
        Debug.Log("Cost:" + MahShip.getCost());
        */

        //adding single components at a time
        CaravelInterface Test = new PlainShip();
        Test = new Caravel_Sails(Test);
        Test = new Caravel_Plating(Test);
        Test = new Caravel_Lantern(Test);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
