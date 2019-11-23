using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleshipCreator : FactoryCreator
{
    public override GameObject ConstructObject(PlayerType playerType)
    {
        GameObject ship = Resources.Load<GameObject>("Battleship");
        GameObject newShip = Instantiate(ship);
        newShip.GetComponent<ShipController>().SetOwner(playerType);
        return newShip;
    }
}
