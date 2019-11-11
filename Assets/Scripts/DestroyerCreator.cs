using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerCreator : ShipCreator
{
    public override GameObject ConstructShip()
    {
        GameObject ship = Resources.Load<GameObject>("Destroyer");
        GameObject newShip = Instantiate(ship);
        newShip.AddComponent<ShipController>();
        return newShip;
    }
}
