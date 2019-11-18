using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBindSystem : TModuleSystem
{
    [SerializeField]
    private MaterialsUISystem materialsUISystem;

    [SerializeField]
    private MaterialsModuleSystem materialsModuleSystem;

    public override void Execute()
    {
        materialsUISystem.Notify<IronUIBinder>(materialsModuleSystem.MatData.GetIron().ToString());
        materialsUISystem.Notify<GoldUIBinder>(materialsModuleSystem.MatData.GetGold().ToString());
        materialsUISystem.Notify<OilUIBinder>(materialsModuleSystem.MatData.GetOil().ToString());
    }

    public override void Tick()
    {
        
    }
}
