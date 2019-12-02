using System.Collections.Generic;
using UnityEngine;

public class AIRuleDecision : AIBehaviour
{
    [SerializeField]
    private AIModuleData AIModuleData;

    [SerializeField]
    private AIDecisions AIDecisions;

    [SerializeField]
    private List<AIRuleHandler> aIRuleHandlers;

    public override void Process()
    {
        List<string> concl = AIDecisions.GetRule();
        AIRuleData ruleData = FindRuleData(concl);
        ExecuteRule(ruleData);
    }

    private AIRuleData FindRuleData(List<string> concl)
    {
        AIRuleData elem = null;

        for (int i = 0; i < aIRuleHandlers.Count; ++i)
        {
            elem = aIRuleHandlers[i].AIRules.Find((x) => x.Conditions.Equals(concl));
            if (elem != null)
            {
                break;
            } 
            else
            {
                continue;
            }
        }

        return elem;
    }

    private void ExecuteRule(AIRuleData aIRule)
    {
        for (int i = 0; i < aIRule.Conclusions.Count; ++i)
        {
            aIRule.Conclusions[i].Invoke();
        }
    }
}
