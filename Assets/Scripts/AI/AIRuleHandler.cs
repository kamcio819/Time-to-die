using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIRuleHandler : MonoBehaviour
{
    [SerializeField]
    private List<AIRuleData> aIRules;

    public List<AIRuleData> AIRules { get => aIRules; set => aIRules = value; }
}
