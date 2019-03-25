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
        CaravelInterface MahShip = new Caravel_Plating(new Caravel_Lantern(new PlainShip()));
        Debug.Log("Description:"+MahShip.getDescription());
        Debug.Log("Cost:" + MahShip.getCost());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
