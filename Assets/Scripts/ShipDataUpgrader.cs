using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDataUpgrader : MonoBehaviour
{
    [SerializeField]
    private List<ShipData> shipsData = default;

    public void UpgradeHealth()
    {
        ShipData sd = shipsData[Random.Range(0, shipsData.Count - 1)];
        sd.ShipDataContainer.AddMaxHealth(10f);
    }

    public void UpgradeMove()
    {
        ShipData sd = shipsData[Random.Range(0, shipsData.Count - 1)];
        sd.ShipDataContainer.AddMovementRange(1);
    }

    public void UpgradeDamage()
    {
        ShipData sd = shipsData[Random.Range(0, shipsData.Count - 1)];
        sd.ShipDataContainer.AddDamage(5f);
    }
}
