using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CorvetteCreator : ShipCreator
{
    public override GameObject ConstructShip()
    {
        GameObject ship = Resources.Load<GameObject>("Corvette");
        GameObject newShip = Instantiate(ship);
        newShip.AddComponent<ShipController>();
        return newShip;
    }
}
