using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleshipCreator : ShipCreator
{
    public override GameObject ConstructShip()
    {
        GameObject ship = Resources.Load<GameObject>("Battleship");
        GameObject newShip = Instantiate(ship);
        newShip.AddComponent<ShipController>();
        return newShip;
    }
}
