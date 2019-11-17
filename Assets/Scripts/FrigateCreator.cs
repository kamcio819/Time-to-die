using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrigateCreator : FactoryCreator
{
    public override GameObject ConstructObject()
    {
        GameObject ship = Resources.Load<GameObject>("Frigate");
        GameObject newShip = Instantiate(ship);
        return newShip;
    }
}
