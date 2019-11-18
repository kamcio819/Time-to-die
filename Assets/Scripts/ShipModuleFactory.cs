using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipType
{
    Battleship,
    Corvette,
    Cruiser,
    Destroyer,
    Frigate
}

public class ShipModuleFactory : IModuleSystem
{
    private Dictionary<ShipType, FactoryCreator> factories;

    public GameObject ConstructShip(ShipType obj)
    {
        return factories[obj].ConstructObject();
    }

    public override void Execute()
    {
        
    }

    public override void Initialize()
    {
        factories = new Dictionary<ShipType, FactoryCreator>
        {
            { ShipType.Battleship, new  BattleshipCreator() },
            { ShipType.Corvette, new CorvetteCreator() },
            { ShipType.Cruiser, new CruiserCreator() },
            { ShipType.Destroyer, new DestroyerCreator() },
            { ShipType.Frigate, new FrigateCreator() }
        };
    }
}