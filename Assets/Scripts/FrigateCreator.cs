using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrigateCreator : FactoryCreator
{
    public override GameObject ConstructObject(PlayerType playerType)
    {
        GameObject ship = Resources.Load<GameObject>("Frigate");
        GameObject newShip = Instantiate(ship);
        newShip.GetComponent<ShipController>().SetOwner(playerType);
        return newShip;
    }
}
