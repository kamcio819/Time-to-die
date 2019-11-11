using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct Data
{
    [SerializeField]
    [Range(0, 50f)]
    float damage;

    [SerializeField]
    [Range(1, 4)]
    int moveRange;

    [SerializeField]
    [Range(0, 8f)]
    float shootingRange;
}

[CreateAssetMenu(fileName = "ShipData", menuName = "Ships/Data", order = 1)]
[PreferBinarySerialization]
public class ShipData :  ScriptableObject
{
    [SerializeField]
    Data shipData;

    [SerializeField]
    private ParticleSystem damageParticle;
}
