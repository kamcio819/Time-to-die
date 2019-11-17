using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiserCreator : FactoryCreator
{
    public override GameObject ConstructObject()
    {
        GameObject ship = Resources.Load<GameObject>("Cruiser");
        GameObject newShip = Instantiate(ship);
        return newShip;
    }
}
