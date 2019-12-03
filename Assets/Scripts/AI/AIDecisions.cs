using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDecisions : MonoBehaviour
{
    [SerializeField]
    private ShipModuleSystem shipModuleSystem;

    [SerializeField]
    private MaterialsModuleSystem materialsModuleSystem;

    [SerializeField]
    private UpgradeModuleSystem upgradeModuleSystem;

    private List<string> decissions = new List<string>();

    public List<string> GetRule()
    {
        List<GameObject> enemyOil, enemyGold, enemyIron, playerOil, playerGold, playerIron;
        CollectMaterialsData(out enemyOil, out enemyGold, out enemyIron, out playerOil, out playerGold, out playerIron);

        List<GameObject> playerBattleships, playerCorvettes, playerCruisers, playerDestroyers, playerFrigates, enemyBattleships, enemyCorvettes, enemyCruisers, enemyDestroyers, enemyFrigates;
        CollectShipsData(out playerBattleships, out playerCorvettes, out playerCruisers, out playerDestroyers, out playerFrigates, out enemyBattleships, out enemyCorvettes, out enemyCruisers, out enemyDestroyers, out enemyFrigates);

        List<UpgradeType> playerUpgrades, enemyUpgrades, playerHealthUpgrades, playerDamageUpgrades, playerRangeUpgrades, enemyHealthUpgrades, enemyDamageUpgrades, enemyRangeUpgrades;
        CollectUpgradesData(out playerUpgrades, out enemyUpgrades, out playerHealthUpgrades, out playerDamageUpgrades, out playerRangeUpgrades, out enemyHealthUpgrades, out enemyDamageUpgrades, out enemyRangeUpgrades);

        decissions.Clear();

        if (Time.time > 500)
        {
            if (playerUpgrades.Count > enemyUpgrades.Count)
            {
                if (playerHealthUpgrades.Count > enemyHealthUpgrades.Count)
                {

                }

                if (playerDamageUpgrades.Count > enemyDamageUpgrades.Count)
                {

                }

                if (playerRangeUpgrades.Count > enemyRangeUpgrades.Count)
                {

                }
            }
        }

        if (Time.time > 300)
        {
            if (playerBattleships.Count * 1.5f > enemyBattleships.Count)
            {

            }

            if (playerCorvettes.Count * 1.5f > enemyCorvettes.Count)
            {

            }

            if (playerCruisers.Count * 1.5f > enemyCruisers.Count)
            {

            }

            if (playerDestroyers.Count * 1.5f > enemyDestroyers.Count)
            {

            }

            if (playerFrigates.Count * 1.5f > enemyFrigates.Count)
            {

            }
        } else
        {


            if (enemyOil.Count * 2 < playerOil.Count)
            {
                decissions.Add("TO FEW OIL");
                decissions.Add("TIME LESS THAN 5 MINUTES");
                return decissions;
            }

            if (enemyGold.Count * 2 < playerGold.Count)
            {
                decissions.Add("TO FEW GOLD");
                decissions.Add("TIME LESS THAN 5 MINUTES");
                return decissions;
            }

            if (enemyIron.Count * 2 < playerIron.Count)
            {
                decissions.Add("TO FEW IRON");
                decissions.Add("TIME LESS THAN 5 MINUTES");
                return decissions;
            }

            if (enemyOil.Count < enemyGold.Count && enemyOil.Count < enemyIron.Count)
            {
                decissions.Add("TO FEW OIL");
                decissions.Add("TIME LESS THAN 5 MINUTES");
                return decissions;
            }

            if (enemyOil.Count <= enemyGold.Count * 2)
            {
                decissions.Add("TO FEW OIL");
                decissions.Add("TIME LESS THAN 5 MINUTES");
                return decissions;
            }

            if (enemyGold.Count < enemyOil.Count)
            {
                decissions.Add("TO FEW GOLD");
                decissions.Add("TIME LESS THAN 5 MINUTES");
                return decissions;
            }

            if (enemyIron.Count < enemyOil.Count)
            {
                decissions.Add("TO FEW IRON");
                decissions.Add("TIME LESS THAN 5 MINUTES");
                return decissions;
            }
        }
        return null;
    }

    private void CollectUpgradesData(out List<UpgradeType> playerUpgrades, out List<UpgradeType> enemyUpgrades, out List<UpgradeType> playerHealthUpgrades, out List<UpgradeType> playerDamageUpgrades, out List<UpgradeType> playerRangeUpgrades, out List<UpgradeType> enemyHealthUpgrades, out List<UpgradeType> enemyDamageUpgrades, out List<UpgradeType> enemyRangeUpgrades)
    {
        playerUpgrades = upgradeModuleSystem.UpgradeData[PlayerType.PLAYER];
        enemyUpgrades = upgradeModuleSystem.UpgradeData[PlayerType.CPU];
        playerHealthUpgrades = playerUpgrades.FindAll(x => x == UpgradeType.HEALTH);
        playerDamageUpgrades = playerUpgrades.FindAll(x => x == UpgradeType.DAMAGE);
        playerRangeUpgrades = playerUpgrades.FindAll(x => x == UpgradeType.RANGE);
        enemyHealthUpgrades = enemyUpgrades.FindAll(x => x == UpgradeType.HEALTH);
        enemyDamageUpgrades = enemyUpgrades.FindAll(x => x == UpgradeType.DAMAGE);
        enemyRangeUpgrades = enemyUpgrades.FindAll(x => x == UpgradeType.RANGE);
    }

    private void CollectShipsData(out List<GameObject> playerBattleships, out List<GameObject> playerCorvettes, out List<GameObject> playerCruisers, out List<GameObject> playerDestroyers, out List<GameObject> playerFrigates, out List<GameObject> enemyBattleships, out List<GameObject> enemyCorvettes, out List<GameObject> enemyCruisers, out List<GameObject> enemyDestroyers, out List<GameObject> enemyFrigates)
    {
        playerBattleships = shipModuleSystem.PlayerShips.FindAll(x => x.GetComponent<ShipController>().ShipType == ShipType.Battleship);
        playerCorvettes = shipModuleSystem.PlayerShips.FindAll(x => x.GetComponent<ShipController>().ShipType == ShipType.Corvette);
        playerCruisers = shipModuleSystem.PlayerShips.FindAll(x => x.GetComponent<ShipController>().ShipType == ShipType.Cruiser);
        playerDestroyers = shipModuleSystem.PlayerShips.FindAll(x => x.GetComponent<ShipController>().ShipType == ShipType.Destroyer);
        playerFrigates = shipModuleSystem.PlayerShips.FindAll(x => x.GetComponent<ShipController>().ShipType == ShipType.Frigate);
        enemyBattleships = shipModuleSystem.EnemyShips.FindAll(x => x.GetComponent<ShipController>().ShipType == ShipType.Battleship);
        enemyCorvettes = shipModuleSystem.EnemyShips.FindAll(x => x.GetComponent<ShipController>().ShipType == ShipType.Corvette);
        enemyCruisers = shipModuleSystem.EnemyShips.FindAll(x => x.GetComponent<ShipController>().ShipType == ShipType.Cruiser);
        enemyDestroyers = shipModuleSystem.EnemyShips.FindAll(x => x.GetComponent<ShipController>().ShipType == ShipType.Destroyer);
        enemyFrigates = shipModuleSystem.EnemyShips.FindAll(x => x.GetComponent<ShipController>().ShipType == ShipType.Frigate);
    }

    private void CollectMaterialsData(out List<GameObject> enemyOil, out List<GameObject> enemyGold, out List<GameObject> enemyIron, out List<GameObject> playerOil, out List<GameObject> playerGold, out List<GameObject> playerIron)
    {
        enemyOil = materialsModuleSystem.EnemyMines.FindAll(x => x.GetComponent<OilMineController>() != null);
        enemyGold = materialsModuleSystem.EnemyMines.FindAll(x => x.GetComponent<GoldMineController>() != null);
        enemyIron = materialsModuleSystem.EnemyMines.FindAll(x => x.GetComponent<IronMineController>() != null);
        playerOil = materialsModuleSystem.PlayerMines.FindAll(x => x.GetComponent<OilMineController>() != null);
        playerGold = materialsModuleSystem.PlayerMines.FindAll(x => x.GetComponent<GoldMineController>() != null);
        playerIron = materialsModuleSystem.PlayerMines.FindAll(x => x.GetComponent<IronMineController>() != null);
    }
}
