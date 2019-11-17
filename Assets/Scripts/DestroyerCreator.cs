using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerCreator : FactoryCreator
{
    public override GameObject ConstructObject()
    {
        GameObject ship = Resources.Load<GameObject>("Destroyer");
        GameObject newShip = Instantiate(ship);
        return newShip;
    }
}
