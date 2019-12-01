using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDataController : MonoBehaviour, ITurnable
{
    [SerializeField]
    private ShipData playerShipData = default;

    [SerializeField]
    private ShipData enemyShipData = default;

    [SerializeField]
    private ShipController shipController = default;

    [Range(0, 200f)]
    public float health = 100f;

    public int movePoints = 1;

    public int attackPoints = 1;

    public ShipData ShipData { get => GetShipData(); }

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

    private ShipData GetShipData()
    {
        switch (shipController.PlayerType)
        {
            case PlayerType.CPU:
                return enemyShipData;
            case PlayerType.PLAYER:
                return playerShipData;
        }
        return null;
    }

    public void SetData(PlayerType playerType)
    {
        switch(playerType)
        {
            case PlayerType.CPU:
                playerShipData = null;
                break;
            case PlayerType.PLAYER:
                enemyShipData = null;
                break;
        }
    }
}
