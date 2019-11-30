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

    public RuleInductionData RuleInductionData { get => ruleInductionData; }
    public GameTreeData GameTreeData { get => gameTreeData; }

    public void SetPureness(float val)
    {
        RuleInductionData.SetPureness(val);
    }

    public void SetSampleRatio(float val)
    {
        RuleInductionData.SetSampleRatio(val);
    }

    public void SetMinimalPruneBenefit(float val)
    {
        RuleInductionData.SetMinimalPruneBenefit(val);
    }

    public void SetMinimalLeafSize(float val)
    {
        GameTreeData.SetMinimalLeafSize(val);
    }

    public void SetMinimalSizeForSplit(float val)
    {
        GameTreeData.SetMinimalSizeForSplit(val);
    }

    public void SetMaximalDepth(float val)
    {
        GameTreeData.SetMaximalDepth(val);
    }

    public void SetConfidence(float val)
    {
        GameTreeData.SetConfidence(val);
    }

    public void SetMinimalGain(float val)
    {
        GameTreeData.SetMinimalGain(val);
    }
}
