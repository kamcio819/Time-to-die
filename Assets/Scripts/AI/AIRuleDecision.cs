using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRuleDecision : AIBehaviour
{
    [SerializeField]
    private AIModuleData AIModuleData;

    [SerializeField]
    private ShipModuleSystem shipModuleSystem;

    public override void Process()
    {
        shipModuleSystem.InstantiateCPUShip(ShipType.Battleship);
    }
}
