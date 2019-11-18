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
    private InformationUISystem informationUISystem;

    private int turnCount = 1;

    public override void TurnFinishUnit()
    {
        turnCount++;
        materialsUISystem.Notify<IronUIBinder>(materialsModuleSystem.MatData.GetIron().ToString());
        materialsUISystem.Notify<GoldUIBinder>(materialsModuleSystem.MatData.GetGold().ToString());
        materialsUISystem.Notify<OilUIBinder>(materialsModuleSystem.MatData.GetOil().ToString());
        informationUISystem.Notify<InfoUIBinder>("Day " + turnCount.ToString());
    }

    public override void Tick()
    {
        materialsUISystem.Notify<IronUIBinder>(materialsModuleSystem.MatData.GetIron().ToString());
        materialsUISystem.Notify<GoldUIBinder>(materialsModuleSystem.MatData.GetGold().ToString());
        materialsUISystem.Notify<OilUIBinder>(materialsModuleSystem.MatData.GetOil().ToString());
    }
}
