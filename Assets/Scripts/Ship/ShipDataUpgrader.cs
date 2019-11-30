using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDataUpgrader : MonoBehaviour
{
    [SerializeField]
    private List<ShipData> shipsData = default;

    public void UpgradeHealth(float health)
    {
        ShipData sd = shipsData[Random.Range(0, shipsData.Count - 1)];
        sd.ShipDataContainer.AddMaxHealth(health);
    }

    public void UpgradeMove(int range)
    {
        ShipData sd = shipsData[Random.Range(0, shipsData.Count - 1)];
        sd.ShipDataContainer.AddMovementRange(range);
    }

    public void UpgradeDamage(float damage)
    {
        ShipData sd = shipsData[Random.Range(0, shipsData.Count - 1)];
        sd.ShipDataContainer.AddDamage(damage);
    }
}
