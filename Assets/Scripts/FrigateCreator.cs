using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrigateCreator : ShipCreator
{
    public override GameObject ConstructShip()
    {
        GameObject ship = Resources.Load<GameObject>("Frigate");
        GameObject newShip = Instantiate(ship);
        newShip.AddComponent<ShipController>();
        return newShip;
    }
}
