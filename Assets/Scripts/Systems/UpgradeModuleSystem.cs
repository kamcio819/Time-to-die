using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeModuleSystem : ITEModuleSystem
{
    [SerializeField]
    private ShipDataUpgrader shipDataUpgrader = default;

    private UpgradeButton[] upgradeButtons;

    private void OnEnable()
    {
        for (int i = 0; i < upgradeButtons.Length; ++i)
        {
            upgradeButtons[i].ButtonPressed += UpgradePlayerShip;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < upgradeButtons.Length; ++i)
        {
            upgradeButtons[i].ButtonPressed += UpgradePlayerShip;
        }
    }

    private void UpgradePlayerShip(UpgradeType obj)
    {
        if (ResourcesCheckerModuleSystem.CheckResources(obj, true, PlayerType.PLAYER))
        {
            switch (obj)
            {
                case UpgradeType.DAMAGE:
                    shipDataUpgrader.UpgradeDamage(10f, PlayerType.PLAYER);
                    break;
                case UpgradeType.HEALTH:
                    shipDataUpgrader.UpgradeHealth(20f, PlayerType.PLAYER);
                    break;
                case UpgradeType.RANGE:
                    shipDataUpgrader.UpgradeMove(1, PlayerType.PLAYER);
                    break;
                default:
                    break;
            }
        }
    }

    public void UpgradeCPUShip(UpgradeType obj)
    {
        if (ResourcesCheckerModuleSystem.CheckResources(obj, true, PlayerType.CPU))
        {
            switch (obj)
            {
                case UpgradeType.DAMAGE:
                    shipDataUpgrader.UpgradeDamage(10f, PlayerType.CPU);
                    break;
                case UpgradeType.HEALTH:
                    shipDataUpgrader.UpgradeHealth(20f, PlayerType.CPU);
                    break;
                case UpgradeType.RANGE:
                    shipDataUpgrader.UpgradeMove(1, PlayerType.CPU);
                    break;
                default:
                    break;
            }
        }
    }

    public void UpgradeCPUShip(int obj)
    {
        if (ResourcesCheckerModuleSystem.CheckResources((UpgradeType)obj, true, PlayerType.CPU))
        {
            switch ((UpgradeType)obj)
            {
                case UpgradeType.DAMAGE:
                    shipDataUpgrader.UpgradeDamage(10f, PlayerType.CPU);
                    break;
                case UpgradeType.HEALTH:
                    shipDataUpgrader.UpgradeHealth(20f, PlayerType.CPU);
                    break;
                case UpgradeType.RANGE:
                    shipDataUpgrader.UpgradeMove(1, PlayerType.CPU);
                    break;
                default:
                    break;
            }
        }
    }

    public override void Exit() {}

    public override void Initialize()
    {
        upgradeButtons = FindObjectsOfType<UpgradeButton>();
    }

    public override void Tick() {}

    public override void TurnFinishUnit() {}
}
