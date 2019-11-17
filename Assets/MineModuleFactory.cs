using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MineType
{
    GOLD,
    OIL,
    IRON
}

public class MineModuleFactory : IModuleSystem 
{
    private Dictionary<MineType, FactoryCreator> factories;

    public GameObject ConstructShip(MineType obj)
    {
        return factories[obj].ConstructObject();
    }

    public override void Initialize()
    {
        factories = new Dictionary<MineType, FactoryCreator>
        {
            { MineType.GOLD, new  GoldMineCreator() },
            { MineType.IRON, new IronMineCreator() },
            { MineType.OIL, new OilMineCreator() },
        };
    }
}
