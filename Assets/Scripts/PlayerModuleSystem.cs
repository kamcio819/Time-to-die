using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModuleSystem : ITEModuleSystem
{
    [SerializeField]
    private PlayerDataController playerDataController;

    public PlayerDataController PlayerDataController { get => playerDataController; }

    public override void Exit()
    {
    }

    public override void Initialize()
    {
    }

    public override void Tick()
    {
    }

    public override void TurnFinishUnit()
    {
    }
}
