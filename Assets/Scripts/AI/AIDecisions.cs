using System;
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

    private List<string> shipRule = new List<string>();
    private List<string> upgradeRule = new List<string>();
    private List<string> materialsRule = new List<string>();

    private void Awake()
    {
        InitializeList(shipRule);
        InitializeList(upgradeRule);
        InitializeList(materialsRule);
    }

    private void InitializeList(List<string> rule)
    {
        for(int i = 0; i < 2; ++i)
        {
            rule.Add("");
        }
    }

    private void ClearList(List<string> rule)
    {
        for (int i = 0; i < rule.Count; ++i)
        {
            rule[i] = string.Empty;
        }
    }

    public Tuple<List<string>, List<string>, List<string>> GetRule()
    {
        List<GameObject> enemyOil, enemyGold, enemyIron, playerOil, playerGold, playerIron;
        CollectMaterialsData(out enemyOil, out enemyGold, out enemyIron, out playerOil, out playerGold, out playerIron);

        List<GameObject> playerBattleships, playerCorvettes, playerCruisers, playerDestroyers, playerFrigates, enemyBattleships, enemyCorvettes, enemyCruisers, enemyDestroyers, enemyFrigates;
        CollectShipsData(out playerBattleships, out playerCorvettes, out playerCruisers, out playerDestroyers, out playerFrigates, out enemyBattleships, out enemyCorvettes, out enemyCruisers, out enemyDestroyers, out enemyFrigates);

        List<UpgradeType> playerUpgrades, enemyUpgrades, playerHealthUpgrades, playerDamageUpgrades, playerRangeUpgrades, enemyHealthUpgrades, enemyDamageUpgrades, enemyRangeUpgrades;
        CollectUpgradesData(out playerUpgrades, out enemyUpgrades, out playerHealthUpgrades, out playerDamageUpgrades, out playerRangeUpgrades, out enemyHealthUpgrades, out enemyDamageUpgrades, out enemyRangeUpgrades);

        ClearList(shipRule);
        ClearList(materialsRule);
        ClearList(upgradeRule);

        if (Time.time > 500)
        {
            if (playerUpgrades.Count > enemyUpgrades.Count)
            {
                if (playerHealthUpgrades.Count > enemyHealthUpgrades.Count)
                {
                    upgradeRule[0] = ("PLAYER HEALTH MORE THAN ENEMY");
                    upgradeRule[1] = ("AFTER 500 SECONDS");
                }
                else if (playerDamageUpgrades.Count > enemyDamageUpgrades.Count)
                {
                    upgradeRule[0] = ("PLAYER DAMAGE MORE THAN ENEMY");
                    upgradeRule[1] = ("AFTER 500 SECONDS");
                }
                else if (playerRangeUpgrades.Count > enemyRangeUpgrades.Count)
                {
                    upgradeRule[0] = ("PLAYER RANGE MORE THAN ENEMY");
                    upgradeRule[1] = ("AFTER 500 SECONDS");
                }
            }
        }

        if (Time.time > 300)
        {
            if (playerBattleships.Count > enemyBattleships.Count * 1.75f)
            {
                shipRule[0] = ("MORE PLAYER BATTLESHIPS");
                shipRule[1] = ("AFTER 300 SECONDS");
            }
            else if (playerCorvettes.Count  > enemyCorvettes.Count * 1.75f)
            {
                shipRule[0] = ("MORE PLAYER CORVETTES");
                shipRule[1] = ("AFTER 300 SECONDS");
            }
            else if (playerCruisers.Count > enemyCruisers.Count * 1.75f)
            {
                shipRule[0] = ("MORE PLAYER CRUISERS");
                shipRule[1] = ("AFTER 300 SECONDS");
            }
            else if (playerDestroyers.Count > enemyDestroyers.Count * 1.75f)
            {
                shipRule[0] = ("MORE PLAYER DESTROYERS");
                shipRule[1] = ("AFTER 300 SECONDS");
            }
            else if (playerFrigates.Count > enemyFrigates.Count * 1.75f)
            {
                shipRule[0] = ("MORE PLAYER FRIGATES");
                shipRule[1] = ("AFTER 300 SECONDS");
            }
            else if(playerDestroyers.Count > enemyFrigates.Count * 3f)
            {
                shipRule[0] = ("MORE PLAYER DESTROYERS THAN PLAYER 3X FRIGATES");
                shipRule[1] = ("AFTER 300 SECONDS");
            }
            else if(playerBattleships.Count > enemyCorvettes.Count * 2f)
            {
                shipRule[0] = ("MORE PLAYER BATTLESHIPS THAN PLAYER 2X CORVETTES");
                shipRule[1] = ("AFTER 300 SECONDS");
            }
            else if (playerBattleships.Count > enemyCruisers.Count * 2f)
            {
                shipRule[0] = ("MORE PLAYER BATTLESHIPS THAN PLAYER 2X CRUISERS");
                shipRule[1] = ("AFTER 300 SECONDS");
            }
        } 
        else
        {
            if (enemyOil.Count * 2 < playerOil.Count)
            {
                materialsRule[0] = ("TO FEW OIL");
                materialsRule[1] = ("TIME LESS THAN 5 MINUTES");
            }
            else if (enemyGold.Count * 2 < playerGold.Count)
            {
                materialsRule[0] = ("TO FEW GOLD");
                materialsRule[1] = ("TIME LESS THAN 5 MINUTES");
            }
            else if (enemyIron.Count * 2 < playerIron.Count)
            {
                materialsRule[0] = ("TO FEW IRON");
                materialsRule[1] = ("TIME LESS THAN 5 MINUTES");
            }
            else if (enemyOil.Count < enemyGold.Count && enemyOil.Count < enemyIron.Count)
            {
                materialsRule[0] = ("TO FEW OIL");
                materialsRule[1] = ("TIME LESS THAN 5 MINUTES");
            }
            else if (enemyOil.Count <= enemyGold.Count * 2)
            {
                materialsRule[0] = ("TO FEW OIL");
                materialsRule[1] = ("TIME LESS THAN 5 MINUTES");
            } 
            else if (enemyGold.Count < enemyOil.Count)
            {
                materialsRule[0] = ("TO FEW GOLD");
                materialsRule[1] = ("TIME LESS THAN 5 MINUTES");
            }
            else if (enemyIron.Count < enemyOil.Count)
            {
                materialsRule[0] = ("TO FEW IRON");
                materialsRule[1] = ("TIME LESS THAN 5 MINUTES");
            }
        }

        return new Tuple<List<string>, List<string>, List<string>>(upgradeRule, shipRule, materialsRule);
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
