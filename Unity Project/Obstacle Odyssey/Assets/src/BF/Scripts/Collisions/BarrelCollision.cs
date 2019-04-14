/* Brandon Foss
 * This script inherits from the base collision class to perform
 * all collision related methods for a barrel impact. The base
 * class was created to default to a barrel hit so nothing had
 * to be changed methodwise.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCollision : Collision
{
    void Start()
    {
        base.DoInitialization(); // calls base class initialization
    }

}

