using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorvetteCreator : ShipCreator
{
    public override GameObject ConstructShip()
    {
        GameObject ship = Resources.Load<GameObject>("Corvette");
        GameObject newShip = Instantiate(ship);
        return newShip;
    }
}
