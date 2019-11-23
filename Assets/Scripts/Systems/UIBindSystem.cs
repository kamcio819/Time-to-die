using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBindSystem : TModuleSystem
{
    [SerializeField]
    private MaterialsUISystem materialsUISystem = default;

    [SerializeField]
    private MaterialsModuleSystem materialsModuleSystem  = default;

    [SerializeField]
    private PlayerModuleSystem playerModuleSystem = default;

    [SerializeField]
    private InformationUISystem informationUISystem = default;

    [SerializeField]
    private StatsUISystem statsUISystem = default;

    private int turnCount = 1;

    public override void TurnFinishUnit()
    {
        turnCount++;
        materialsUISystem.Notify<IronUIBinder>(materialsModuleSystem.PlayerMaterialData.GetIron().ToString());
        materialsUISystem.Notify<GoldUIBinder>(materialsModuleSystem.PlayerMaterialData.GetGold().ToString());
        materialsUISystem.Notify<OilUIBinder>(materialsModuleSystem.PlayerMaterialData.GetOil().ToString());
        statsUISystem.Notify<StatsUIBinder>(playerModuleSystem.PlayerDataHandler.GetPoints().ToString());
        informationUISystem.Notify<InfoUIBinder>("Day " + turnCount.ToString());
    }

    public override void Tick()
    {
        materialsUISystem.Notify<IronUIBinder>(materialsModuleSystem.PlayerMaterialData.GetIron().ToString());
        materialsUISystem.Notify<GoldUIBinder>(materialsModuleSystem.PlayerMaterialData.GetGold().ToString());
        materialsUISystem.Notify<OilUIBinder>(materialsModuleSystem.PlayerMaterialData.GetOil().ToString());
    }
}
