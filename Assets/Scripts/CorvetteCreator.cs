using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorvetteCreator : FactoryCreator
{
    public override GameObject ConstructObject()
    {
        GameObject ship = Resources.Load<GameObject>("Corvette");
        GameObject newShip = Instantiate(ship);
        return newShip;
    }
}
