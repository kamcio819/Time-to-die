using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipType
{
    Battleship,
    Corvette,
    Cruiser,
    Destroyer,
    Frigate
}

public class ShipButton : MonoBehaviour
{
    [SerializeField]
    private ShipType shipType = default;

    public Action<ShipType> CreateShip;

    public void SelectShip()
    {
        CreateShip?.Invoke(shipType);
    }
}
