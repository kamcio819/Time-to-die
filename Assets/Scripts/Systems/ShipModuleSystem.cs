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
    private EventModuleSystem eventModuleSystem = default;

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

    public List<GameObject> PlayerShips { get => playerShips; }
    public List<GameObject> EnemyShips { get => enemyShips; }
    public List<GameObject> AllShips { get => allShips; }

    public Action<Vector3> ShipConstructed;

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
        else
        {
            eventModuleSystem.Notify<EventUIBinder>("Not enough founds to create SHIP: " + obj.ToString());
        }
    }

    public void InstantiateCPUShip(ShipType obj)
    {
        if (ResourcesCheckerModuleSystem.CheckResources(obj, true, PlayerType.CPU))
        {
            GameObject ship = shipModuleFactory.ConstructShip(obj, PlayerType.CPU);
            shipPlacer.PlaceCPUShip(ship);
            enemyShips.Add(ship);
            allShips.Add(ship);
            ShipConstructed?.Invoke(ship.transform.position);
        }
    }

    public void InstantiateCPUShip(int obj)
    {
        if (ResourcesCheckerModuleSystem.CheckResources((ShipType)obj, true, PlayerType.CPU))
        {
            GameObject ship = shipModuleFactory.ConstructShip((ShipType)obj, PlayerType.CPU);
            shipPlacer.PlaceCPUShip(ship);
            enemyShips.Add(ship);
            allShips.Add(ship);
            ShipConstructed?.Invoke(ship.transform.position);
        }
    }

    private void SetUpShips()
    {
        GameObject ship = shipModuleFactory.ConstructShip(ShipType.Battleship, PlayerType.PLAYER);
        playerShips.Add(ship);
        allShips.Add(ship);
        shipPlacer.PlaceShipOnInitialPosition(ship, PlayerType.PLAYER);

        ship = null;

        ship = shipModuleFactory.ConstructShip(ShipType.Frigate, PlayerType.PLAYER);
        playerShips.Add(ship);
        allShips.Add(ship);
        shipPlacer.PlaceShipOnInitialPosition(ship, PlayerType.PLAYER);

        ship = null;

        ship = shipModuleFactory.ConstructShip(ShipType.Battleship, PlayerType.CPU);
        shipPlacer.PlaceShipOnInitialPosition(ship, PlayerType.CPU);
        enemyShips.Add(ship);
        allShips.Add(ship);
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

    private void Start()
    {
        SetUpShips();
    }
}
