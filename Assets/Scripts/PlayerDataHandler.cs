using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHandler : ITEModuleSystem
{
    [SerializeField]
    private PlayerData playerData = default;

    [SerializeField]
    private ShipModuleSystem shipModuleSystem = default;

    private float timer = 0f;

    public override void Exit()
    {
    }

    public override void Initialize()
    {
    }

    public override void Tick()
    {
        timer += Time.deltaTime;
    }

    public override void TurnFinishUnit()
    {
        playerData.AddTime((int)timer);
        playerData.AddShipsAmount(shipModuleSystem.GetCreatedShips());
        timer = 0f;
    }

    public float GetPoints()
    {
        return playerData.ShipsDestroyed * 2f + playerData.ShipsAmount - playerData.Time * 0.35f;
    }
}
