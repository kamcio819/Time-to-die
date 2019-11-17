using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleshipCreator : FactoryCreator
{
    public override GameObject ConstructObject()
    {
        GameObject ship = Resources.Load<GameObject>("Battleship");
        GameObject newShip = Instantiate(ship);
        return newShip;
    }
}
