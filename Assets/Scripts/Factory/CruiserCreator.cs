using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiserCreator : FactoryCreator
{
    public override GameObject ConstructObject(PlayerType playerType)
    {
        GameObject ship = Resources.Load<GameObject>("Cruiser");
        GameObject newShip = Instantiate(ship);
        newShip.GetComponent<ShipController>().SetOwner(playerType);
        return newShip;
    }
}
