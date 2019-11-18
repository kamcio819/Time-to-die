using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesCheckerModuleSystem : ITEModuleSystem
{
    private static MaterialsModuleSystem materialsModuleSystem;

    private static Dictionary<MineType, Tuple<int, int, int>> minesCost = new Dictionary<MineType, Tuple<int, int, int>>
    {
        {MineType.GOLD, new Tuple<int, int, int>(2,4,4) },
        {MineType.IRON, new Tuple<int, int, int>(4,1,4) },
        {MineType.OIL, new Tuple<int, int, int>(5,2,5) }
    };

    private static Dictionary<UpgradeType, Tuple<int, int, int>> upgradesCost = new Dictionary<UpgradeType, Tuple<int, int, int>>
    {
        {UpgradeType.DAMAGE, new Tuple<int, int, int>(10, 2, 10) },
        {UpgradeType.HEALTH, new Tuple<int, int, int>(5, 10, 10) },
        {UpgradeType.RANGE, new Tuple<int, int, int>(5,15,5) }
    };

    private static Dictionary<ShipType, Tuple<int, int, int>> shipsCost = new Dictionary<ShipType, Tuple<int, int, int>>
    {
        {ShipType.Battleship, new Tuple<int, int, int>(3, 6, 6) },
        {ShipType.Corvette, new Tuple<int, int, int>(4, 3, 3) },
        {ShipType.Cruiser, new Tuple<int, int, int>(4, 2, 2) },
        {ShipType.Destroyer, new Tuple<int, int, int>(6, 10, 10) },
        {ShipType.Frigate, new Tuple<int, int, int>(6, 5, 5) },
    };

    public static bool CheckResources(MineType mine)
    {
        bool flag = false;
        if (CheckEnoughResources(materialsModuleSystem.MatData, minesCost[mine]))
        {
            flag = true;
        }
        return flag;
    }

    public static bool CheckResources(UpgradeType upgrade)
    {
        bool flag = false;
        if (CheckEnoughResources(materialsModuleSystem.MatData, upgradesCost[upgrade]))
        {
            flag = true;
        }
        return flag;
    }

    public static bool CheckResources(ShipType ship)
    {
        bool flag = false;
        if (CheckEnoughResources(materialsModuleSystem.MatData, shipsCost[ship]))
        {
            flag = true;
        }
        return flag;
    }

    private static bool CheckEnoughResources(MaterialsData matData, Tuple<int, int, int> tuple)
    {
        if(matData.GetGold() >= tuple.Item1 && matData.GetOil() >= tuple.Item2 && matData.GetIron() >= tuple.Item3)
        {
            materialsModuleSystem.RemoveResources(tuple);
            return true;
        }
        return false;
    }

    public override void TurnFinishUnit() {}
    public override void Exit() {}

    public override void Initialize()
    {
        materialsModuleSystem = FindObjectOfType<MaterialsModuleSystem>();
    }
    public override void Tick() {}
}
