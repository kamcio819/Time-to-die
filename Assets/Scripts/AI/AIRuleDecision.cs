using System;
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
            elem = aIRuleHandlers[i].AIRules.Find(x=>ListEqual(x, concl));
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

    private bool ListEqual(AIRuleData x, List<string> concl)
    {
        bool contains = false;

        for(int i = 0; i < concl.Count; ++i)
        {
            if (x.Conditions.Contains(concl[i]))
            {
                contains = true;
                continue;
            } 
            else
            {
                contains = false;
                break;
            }
        }

        return contains;
    }

    private void ExecuteRule(AIRuleData aIRule)
    {
        for (int i = 0; i < aIRule.Conclusions.Count; ++i)
        {
            aIRule.Conclusions[i].Invoke();
        }
    }
}
