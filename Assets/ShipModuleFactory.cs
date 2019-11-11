using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModuleFactory : IModuleSystem
{
    private Dictionary<ShipType, ShipCreator> factories;

    public GameObject ConstructShip(ShipType obj)
    {
        return factories[obj].ConstructShip();
    }

    public override void Initialize()
    {
        factories = new Dictionary<ShipType, ShipCreator>
        {
            { ShipType.Battleship, new  BattleshipCreator() },
            { ShipType.Corvette, new CorvetteCreator() },
            { ShipType.Cruiser, new CruiserCreator() },
            { ShipType.Destroyer, new DestroyerCreator() },
            { ShipType.Frigate, new FrigateCreator() }
        };
    }
}