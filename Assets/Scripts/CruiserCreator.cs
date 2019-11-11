using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiserCreator : ShipCreator
{
    public override GameObject ConstructShip()
    {
        GameObject ship = Resources.Load<GameObject>("Cruiser");
        GameObject newShip = Instantiate(ship);
        return newShip;
    }
}
