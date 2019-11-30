using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIModuleSystem : ITEModuleSystem
{
    [SerializeField]
    private MaterialsModuleSystem materialsModuleSystem;

    [SerializeField]
    private ShipModuleSystem shipModuleSystem;

    [SerializeField]
    private UpgradeModuleSystem upgradeModuleSystem;

    [SerializeField]
    private AIRuleDecision aIRuleDecision;

    [SerializeField]
    private AIGameTree aIGameTree;

    public override void TurnFinishUnit()
    {
        aIRuleDecision.Process();
        aIGameTree.Process();
    }

    public override void Exit()
    {
    }

    public override void Initialize()
    {
    }

    public override void Tick()
    {
    }
}
