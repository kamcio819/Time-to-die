using Assets.Scripts.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AIData", menuName = "AI/Data", order = 1)]
public class AIModuleData : ScriptableObject
{
    [SerializeField]
    private RuleInductionData ruleInductionData;

    [SerializeField]
    private GameTreeData gameTreeData;

    public void SetPureness(float val)
    {
        ruleInductionData.SetPureness(val);
    }

    public void SetSampleRatio(float val)
    {
        ruleInductionData.SetSampleRatio(val);
    }

    public void SetMinimalPruneBenefit(float val)
    {
        ruleInductionData.SetMinimalPruneBenefit(val);
    }

    public void SetMinimalLeafSize(float val)
    {
        gameTreeData.SetMinimalLeafSize(val);
    }

    public void SetMinimalSizeForSplit(float val)
    {
        gameTreeData.SetMinimalSizeForSplit(val);
    }

    public void SetMaximalDepth(float val)
    {
        gameTreeData.SetMaximalDepth(val);
    }

    public void SetConfidence(float val)
    {
        gameTreeData.SetConfidence(val);
    }

    public void SetMinimalGain(float val)
    {
        gameTreeData.SetMinimalGain(val);
    }
}
