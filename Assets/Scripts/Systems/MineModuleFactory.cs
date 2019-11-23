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

    public GameObject ConstructMine(MineType obj, PlayerType pT)
    {
        return factories[obj].ConstructObject(pT);
    }

    public override void TurnFinishUnit()
    {
        
    }

    public override void Initialize()
    {
        factories = new Dictionary<MineType, FactoryCreator>
        {
            { MineType.GOLD, gameObject.AddComponent<GoldMineCreator>() },
            { MineType.IRON, gameObject.AddComponent<IronMineCreator>() },
            { MineType.OIL, gameObject.AddComponent<OilMineCreator>() },
        };
    }
}
