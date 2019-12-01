using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDataUpgrader : MonoBehaviour
{
    [SerializeField]
    private ShipDataController shipDataController;

    [SerializeField]
    private List<ShipData> playerShipsData = default;

    [SerializeField]
    private List<ShipData> enemyShipsData = default;

    private Dictionary<PlayerType, List<ShipData>> UpgradeData = new Dictionary<PlayerType, List<ShipData>>();

    private void Awake()
    {
        UpgradeData.Add(PlayerType.CPU, enemyShipsData);
        UpgradeData.Add(PlayerType.PLAYER, playerShipsData);
    }

    public void UpgradeHealth(float health, PlayerType playerType)
    {
        List<ShipData> shipData = UpgradeData[playerType];
        ShipData sd = shipData[Random.Range(0, playerShipsData.Count - 1)];
        sd.ShipDataContainer.AddMaxHealth(health);
        shipDataController.health = (shipDataController.health * sd.ShipDataContainer.GetMaxHealth()) / 100;
    }

    public void UpgradeMove(int range, PlayerType playerType)
    {
        List<ShipData> shipData = UpgradeData[playerType];
        ShipData sd = shipData[Random.Range(0, playerShipsData.Count - 1)];
        sd.ShipDataContainer.AddMovementRange(range);
    }

    public void UpgradeDamage(float damage, PlayerType playerType)
    {
        List<ShipData> shipData = UpgradeData[playerType];
        ShipData sd = shipData[Random.Range(0, playerShipsData.Count - 1)];
        sd.ShipDataContainer.AddDamage(damage);
    }
}
