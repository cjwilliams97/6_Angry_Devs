using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Using the decorator pattern. Lanterns can be added to your caravel.
 *  Lanters updates the ship visually by attaching lanterns to the front and back of your ship
 *  lanterns will give off light and act as a prerequisite to certain level(s)
 */

public class Caravel_Lantern : ShipDecorator
{
    private static GameObject Attribute;
    //sets the parent game object
    private static GameObject PARENT = GameObject.Find("Caravel");

    private class Lanterns : MonoBehaviour
    {
        public void AddLanterns()
        {
            PARENT = GameObject.Find("Caravel");
            Debug.Log("Instantiating caravel attribute");
            Attribute = Instantiate(Resources.Load("JD/Caravel/caravel_lanterns", typeof(GameObject)), PARENT.transform.position, PARENT.transform.rotation) as GameObject;
            Attribute.transform.localScale = PARENT.transform.lossyScale;
            Attribute.transform.SetParent(PARENT.transform);
            Attribute.transform.localPosition += new Vector3(0.000f, 0.001f, 0.004f);
            return;
        }

    }

    public Caravel_Lantern(CaravelInterface newShip) : base(newShip)
    {
        //currently uses new keyword, but because Plating is a unity MonoBehavior, throws console a warning (not sure how to fix)
        Lanterns newLanterns = new Lanterns();
        newLanterns.AddLanterns();
    }

    public override GameObject getBoat()
    {
        //returns the parent caravel gameobject
        return PARENT;
    }

    public override string getDescription()
    {
        return base.getDescription() + " + LANTERNS";
    }

    public override double getCost()
    {
        return base.getCost() + 2.0f;
    }
}

