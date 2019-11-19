using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBindSystem : TModuleSystem
{
    [SerializeField]
    private MaterialsUISystem materialsUISystem;

    [SerializeField]
    private MaterialsModuleSystem materialsModuleSystem;

    [SerializeField]
    private PlayerModuleSystem playerModuleSystem;

    [SerializeField]
    private InformationUISystem informationUISystem;

    [SerializeField]
    private StatsUISystem statsUISystem;

    private int turnCount = 1;

    public override void TurnFinishUnit()
    {
        turnCount++;
        materialsUISystem.Notify<IronUIBinder>(materialsModuleSystem.MatData.GetIron().ToString());
        materialsUISystem.Notify<GoldUIBinder>(materialsModuleSystem.MatData.GetGold().ToString());
        materialsUISystem.Notify<OilUIBinder>(materialsModuleSystem.MatData.GetOil().ToString());
        statsUISystem.Notify<StatsUIBinder>(playerModuleSystem.PlayerDataController.GetPoints().ToString());
        informationUISystem.Notify<InfoUIBinder>("Day " + turnCount.ToString());
    }

    public override void Tick()
    {
        materialsUISystem.Notify<IronUIBinder>(materialsModuleSystem.MatData.GetIron().ToString());
        materialsUISystem.Notify<GoldUIBinder>(materialsModuleSystem.MatData.GetGold().ToString());
        materialsUISystem.Notify<OilUIBinder>(materialsModuleSystem.MatData.GetOil().ToString());
        statsUISystem.Notify<StatsUIBinder>(playerModuleSystem.PlayerDataController.GetPoints().ToString());
    }
}
