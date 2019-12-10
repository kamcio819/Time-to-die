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
    private List<string> conditions = default;

    [SerializeField]
    private List<UnityEvent> conclusions = default;

    public List<string> Conditions { get => conditions; }
    public List<UnityEvent> Conclusions { get => conclusions; }
}
