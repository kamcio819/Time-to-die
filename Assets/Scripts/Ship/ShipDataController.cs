using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDataController : MonoBehaviour, ITurnable
{
    [SerializeField]
    private ShipData shipData = default;

    [Range(0, 200f)]
    public float health = 100f;

    public int movePoints = 1;

    public int attackPoints = 1;

    public ShipData ShipData { get => shipData; }

    private void Awake()
    {
        TurnModuleSystem.AddCommand(this);
    }

    private void OnDestroy()
    {
        TurnModuleSystem.RemoveCommand(this);
    }

    public void TurnFinishUnit()
    {
        movePoints = 1;
        attackPoints = 1;
    }
}
