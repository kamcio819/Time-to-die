using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModuleSystem : ITEModuleSystem
{
    [SerializeField]
    private ShipModuleFactory shipModuleFactory;

    private ShipButton[] shipButtons;

    [SerializeField]
    private List<GameObject> ships;

    private void OnEnable()
    {
        for(int i = 0; i < shipButtons.Length; ++i)
        {
            shipButtons[i].CreateShip += InstantiateShip;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < shipButtons.Length; ++i)
        {
            shipButtons[i].CreateShip -= InstantiateShip;
        }
    }

    private void InstantiateShip(ShipType obj)
    {
        ships.Add(shipModuleFactory.ConstructShip(obj));
    }

    public override void Exit() {}

    public override void Initialize()
    {
        shipButtons = FindObjectsOfType<ShipButton>();
    }

    public override void Tick() {}
}
