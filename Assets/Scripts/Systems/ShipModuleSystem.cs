using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModuleSystem : ITEModuleSystem
{
    [SerializeField]
    private ShipModuleFactory shipModuleFactory = default;

    [SerializeField]
    private ObjectPlacer shipPlacer;

    private ShipButton[] shipButtons;

    [SerializeField]
    private List<GameObject> ships = default;

    private void OnEnable()
    {
        for(int i = 0; i < shipButtons.Length; ++i)
        {
            shipButtons[i].ButtonPressed += InstantiateShip;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < shipButtons.Length; ++i)
        {
            shipButtons[i].ButtonPressed -= InstantiateShip;
        }
    }

    private void InstantiateShip(ShipType obj)
    {
        ships.Add(shipModuleFactory.ConstructShip(obj));
        shipPlacer.SetCurentObj(ships[ships.Count - 1]);
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

    public override void Execute()
    {
    }
}
