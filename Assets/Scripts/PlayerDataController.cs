using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataController : IEModuleSystem
{
    [SerializeField]
    private PlayerData playerData;

    public override void Exit()
    {
    }

    public override void Initialize()
    {
    }

    public override void TurnFinishUnit()
    {
    }

    public float GetPoints()
    {
        return playerData.ShipsDestroyed * 2f + playerData.ShipsAmount + playerData.Time * 2f;
    }
}
