using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Concrete component for a Plan Caravel object
 * 
 * Fundamental component script for utlizing the decorator method that acts as the 
 * most simple Caravel
 *  */

public class PlainShip : CaravelInterface
{
    public GameObject getBoat()
    {   
        try
        {
            GameObject Ship = GameObject.Find("Caravel");
            return Ship;
        }
        catch
        {
            Debug.Log("Could not find 'Caravel' GameObject");
            return null;
        }
    }

    public string getDescription()
    {
        return "BASE_SHIP:";
    }

    public double getCost()
    {
        return 1.0f;
    }
}
