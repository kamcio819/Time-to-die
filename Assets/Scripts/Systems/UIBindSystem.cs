using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBindSystem : TModuleSystem
{
    [Header("Controllers")]
    [SerializeField]
    private MaterialsModuleSystem materialsModuleSystem  = default;

    [SerializeField]
    private PlayerModuleSystem playerModuleSystem = default;

    [Header("UI Binds")]
    [Space(20)]
    [SerializeField]
    private InformationUISystem informationUISystem = default;

    [SerializeField]
    private ButtonSpriteUISystem buttonSpriteUISystem = default;

    [SerializeField]
    private MaterialsUISystem materialsUISystem = default;

    [SerializeField]
    private StatsUISystem statsUISystem = default;

    private int turnCount = 1;

    public override void TurnFinishUnit()
    {
        turnCount++;
        materialsUISystem.Notify<IronUIBinder>(materialsModuleSystem.MaterialsData[PlayerType.PLAYER].GetIron().ToString());
        materialsUISystem.Notify<GoldUIBinder>(materialsModuleSystem.MaterialsData[PlayerType.PLAYER].GetGold().ToString());
        materialsUISystem.Notify<OilUIBinder>(materialsModuleSystem.MaterialsData[PlayerType.PLAYER].GetOil().ToString());
        statsUISystem.Notify<StatsUIBinder>(playerModuleSystem.PlayerDataHandler.GetPoints().ToString());
        informationUISystem.Notify<InfoUIBinder>("Day " + turnCount.ToString());
    }

    public override void Tick()
    {
        materialsUISystem.Notify<IronUIBinder>(materialsModuleSystem.MaterialsData[PlayerType.PLAYER].GetIron().ToString());
        materialsUISystem.Notify<GoldUIBinder>(materialsModuleSystem.MaterialsData[PlayerType.PLAYER].GetGold().ToString());
        materialsUISystem.Notify<OilUIBinder>(materialsModuleSystem.MaterialsData[PlayerType.PLAYER].GetOil().ToString());

        buttonSpriteUISystem.Notify<ShipUIBinder>("x");
        buttonSpriteUISystem.Notify<MineUIBinder>("x");
        buttonSpriteUISystem.Notify<UpgradeUIBinder>("x");
    }
}
