using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIModuleSystem : ModuleSystem<InitUnit, TickUnit, ExitUnit>
{
    [ContextMenu("Get all units")]
    public void CollectUnits()
    {
        base.GetUnits();
    }
}
