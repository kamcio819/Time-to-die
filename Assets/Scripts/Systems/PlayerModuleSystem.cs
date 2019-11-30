using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModuleSystem : ITEModuleSystem
{
    [SerializeField]
    private PlayerDataHandler playerDataHandler = default;

    public PlayerDataHandler PlayerDataHandler { get => playerDataHandler; }

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
