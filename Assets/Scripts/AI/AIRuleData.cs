using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[PreferBinarySerialization]
[System.Serializable]
public class AIRuleData
{
    [SerializeField]
    private List<string> conditions;

    [SerializeField]
    private List<UnityEvent> conclusions;

    public List<string> Conditions { get => conditions; }
    public List<UnityEvent> Conclusions { get => conclusions; }
}
