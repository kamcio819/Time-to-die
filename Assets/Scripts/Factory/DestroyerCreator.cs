using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerCreator : FactoryCreator
{
    public override GameObject ConstructObject(PlayerType playerType)
    {
        GameObject ship = Resources.Load<GameObject>("Destroyer");
        GameObject newShip = Instantiate(ship);
        newShip.GetComponent<ShipController>().SetOwner(playerType);
        return newShip;
    }
}
