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

    public GameObject ConstructShip(ShipType obj, PlayerType playerType)
    {
        return factories[obj].ConstructObject(playerType);
    }

    public override void TurnFinishUnit()
    {
        
    }

    public override void Initialize()
    {
        factories = new Dictionary<ShipType, FactoryCreator>
        {
            { ShipType.Battleship, gameObject.AddComponent<BattleshipCreator>() },
            { ShipType.Corvette, gameObject.AddComponent<CorvetteCreator>() },
            { ShipType.Cruiser, gameObject.AddComponent<CruiserCreator>() },
            { ShipType.Destroyer, gameObject.AddComponent<DestroyerCreator>() },
            { ShipType.Frigate, gameObject.AddComponent<FrigateCreator>() }
        };
    }
}