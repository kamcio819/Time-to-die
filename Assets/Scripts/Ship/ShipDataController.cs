using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDataController : MonoBehaviour
{
    [SerializeField]
    private ShipData shipData = default;

    [Range(0, 200f)]
    public float health = 100f;

    public int movePoints = 1;

    public int attackPoints = 1;

    public ShipData ShipData { get => shipData; }
}
