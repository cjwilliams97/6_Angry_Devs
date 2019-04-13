using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ShipDecorator : CaravelInterface
{
    protected CaravelInterface temp;

    public ShipDecorator(CaravelInterface newShip)
    { temp = newShip; }

    public virtual GameObject getBoat()
    { return temp.getBoat(); }

    public virtual string getDescription()
    { return temp.getDescription(); }

    public virtual double getCost()
    { return temp.getCost(); }
}
