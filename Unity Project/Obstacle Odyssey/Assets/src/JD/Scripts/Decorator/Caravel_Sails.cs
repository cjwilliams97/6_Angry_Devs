using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Using the decorator pattern. Better Sails can be added to your caravel.
 *  Sails updates the ship visually to larger sails with an emblem, 
 *  will also eventually make the ship able to go faster
 */

public class Caravel_Sails : ShipDecorator
{
    private static GameObject Attribute;
    //sets the parent game object
    private static GameObject PARENT = GameObject.Find("Caravel");

    private class Sails : MonoBehaviour
    {
         public void AddSails()
        {
            PARENT = GameObject.Find("Caravel");
            Debug.Log("Instantiating caravel attribute");
            Attribute = Instantiate(Resources.Load("JD/Caravel/caravel_sails", typeof(GameObject)), PARENT.transform.position, PARENT.transform.rotation) as GameObject;
            Attribute.transform.localScale = PARENT.transform.lossyScale;
            Attribute.transform.SetParent(PARENT.transform);
            Attribute.transform.localPosition += new Vector3(0.001f, 0.001f, 0.004f);
            return;
        }
    }

    public Caravel_Sails(CaravelInterface newShip) : base(newShip)
    {
        //currently uses new keyword, but because Plating is a unity MonoBehavior, throws console a warning (not sure how to fix)
        Sails newSails = new Sails();
        newSails.AddSails();
    }

    public override GameObject getBoat()
    {
        //returns the parent caravel gameobject
        return PARENT;
    }

    public override string getDescription()
    {
        return base.getDescription() + " + SAILS";
    }

    public override double getCost()
    {
        return base.getCost() + 1.0f;
    }
}

