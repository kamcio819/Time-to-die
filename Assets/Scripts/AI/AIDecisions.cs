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
        decissions.Clear();

        if(Time.time > 300)
        {

        }
        else
        {
            var enemyOil = materialsModuleSystem.EnemyMines.FindAll(x => x.GetComponent<OilMineController>() != null);
            var enemyGold = materialsModuleSystem.EnemyMines.FindAll(x => x.GetComponent<GoldMineController>() != null);
            var enemyIron = materialsModuleSystem.EnemyMines.FindAll(x => x.GetComponent<IronMineController>() != null);

            var playerOil = materialsModuleSystem.PlayerMines.FindAll(x => x.GetComponent<OilMineController>() != null);
            var playerGold = materialsModuleSystem.PlayerMines.FindAll(x => x.GetComponent<GoldMineController>() != null);
            var playerIron = materialsModuleSystem.PlayerMines.FindAll(x => x.GetComponent<IronMineController>() != null);

            if(enemyOil.Count * 2 < playerOil.Count)
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

            if(enemyOil.Count <= enemyGold.Count * 2)
            {
                decissions.Add("TO FEW OIL");
                decissions.Add("TIME LESS THAN 5 MINUTES");
                return decissions;
            }

            if(enemyGold.Count < enemyOil.Count)
            {
                decissions.Add("TO FEW GOLD");
                decissions.Add("TIME LESS THAN 5 MINUTES");
                return decissions;
            }

            if(enemyIron.Count < enemyOil.Count)
            {
                decissions.Add("TO FEW IRON");
                decissions.Add("TIME LESS THAN 5 MINUTES");
                return decissions;
            }
        }
        return null;
    }
}
