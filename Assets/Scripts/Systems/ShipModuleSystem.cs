using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModuleSystem : ITEModuleSystem
{
    [Header("Controllers")]
    [SerializeField]
    private ShipModuleFactory shipModuleFactory = default;

    [SerializeField]
    private ObjectPlacer shipPlacer = default;

    private ShipButton[] shipButtons = default;

    [Header("Holders")]
    [Space(20)]
    [SerializeField]
    private List<GameObject> playerShips = default;

    [SerializeField]
    private List<GameObject> allShips = default;

    [SerializeField]
    private List<GameObject> enemyShips = default;

    private int createdShipsIndex = 0;

    private void OnEnable()
    {
        for(int i = 0; i < shipButtons.Length; ++i)
        {
            shipButtons[i].ButtonPressed += InstantiatePlayerShip;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < shipButtons.Length; ++i)
        {
            shipButtons[i].ButtonPressed -= InstantiatePlayerShip;
        }
    }

    private void InstantiatePlayerShip(ShipType obj)
    {
        if (ResourcesCheckerModuleSystem.CheckResources(obj, true, PlayerType.PLAYER))
        {
            GameObject ship = shipModuleFactory.ConstructShip(obj, PlayerType.PLAYER);
            playerShips.Add(ship);
            allShips.Add(ship);
            shipPlacer.SetCurentObj(playerShips[playerShips.Count - 1]);
            createdShipsIndex++;
        }
    }

    public void InstantiateCPUShip(ShipType obj)
    {
        if (ResourcesCheckerModuleSystem.CheckResources(obj, true, PlayerType.CPU))
        {
            GameObject ship = shipModuleFactory.ConstructShip(obj, PlayerType.CPU);
            enemyShips.Add(ship);
            allShips.Add(ship);
        }
    }

    public int GetCreatedShips()
    {
        return createdShipsIndex;
    }

    public override void Exit() {}

    public override void Initialize()
    {
        shipButtons = FindObjectsOfType<ShipButton>();
    }

    public override void Tick()
    {
        shipPlacer.OnUpdate();
    }

    public override void TurnFinishUnit()
    {
        createdShipsIndex = 0;
    }
}
