using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIModuleSystem : ITEModuleSystem
{
    [Header("Controllers")]
    [SerializeField]
    private MaterialsModuleSystem materialsModuleSystem = default;

    [SerializeField]
    private ShipModuleSystem shipModuleSystem = default;

    [SerializeField]
    private UpgradeModuleSystem upgradeModuleSystem = default;

    [Header("AI Modules")]
    [Space(20)]
    [SerializeField]
    private AIRuleDecision aIRuleDecision = default;

    [SerializeField]
    private AIGameTree aIGameTree = default;

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
