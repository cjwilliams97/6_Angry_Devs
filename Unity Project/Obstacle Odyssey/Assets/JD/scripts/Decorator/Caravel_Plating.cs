using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Using the decorator pattern. Plating can be added to your caravel.
 *  Plating updates the ship visually to ahve steel extentions that will eventually influence HP when active
 */

public class Caravel_Plating : ShipDecorator
{
    private static GameObject Attribute;
    //sets the parent game object
    private static GameObject PARENT = GameObject.Find("Caravel");

    private class Plating : MonoBehaviour
    {
         public void AddPlating()
        {
            PARENT = GameObject.Find("Caravel");
            Debug.Log("Instantiating caravel attribute");
            Attribute = Instantiate(Resources.Load("JD/Caravel/caravel_plating", typeof(GameObject)), PARENT.transform.position, PARENT.transform.rotation) as GameObject;
            Attribute.transform.localScale = PARENT.transform.lossyScale;
            Attribute.transform.SetParent(PARENT.transform);
            Attribute.transform.localPosition += new Vector3(0.000f, 0.001f, 0.004f);
            return;
        }

    }

    public Caravel_Plating(CaravelInterface newShip) : base(newShip)
    {
        //currently uses new keyword, but because Plating is a unity MonoBehavior, throws console a warning (not sure how to fix)
        Plating newPlates = new Plating();
        newPlates.AddPlating();
    }

    public override GameObject getBoat()
    {
        //returns the parent caravel gameobject
        return PARENT;
    }

    public override string getDescription()
    {
        return base.getDescription() + " + PLATING";
    }

    public override double getCost()
    {
        return base.getCost() + 2.0f;
    } 
}