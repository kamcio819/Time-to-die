using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeModuleSystem : ITEModuleSystem
{
    [SerializeField]
    private ShipDataUpgrader shipDataUpgrader = default;

    [SerializeField]
    private UpgradeButton[] upgradeButtons;

    private void OnEnable()
    {
        for (int i = 0; i < upgradeButtons.Length; ++i)
        {
            upgradeButtons[i].ButtonPressed += UpgradeShip;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < upgradeButtons.Length; ++i)
        {
            upgradeButtons[i].ButtonPressed += UpgradeShip;
        }
    }

    private void UpgradeShip(UpgradeType obj)
    {
        if (ResourcesCheckerModuleSystem.CheckResources(obj))
        {
            switch (obj)
            {
                case UpgradeType.DAMAGE:
                    shipDataUpgrader.UpgradeDamage(10f);
                    break;
                case UpgradeType.HEALTH:
                    shipDataUpgrader.UpgradeHealth(20f);
                    break;
                case UpgradeType.RANGE:
                    shipDataUpgrader.UpgradeMove(1);
                    break;
                default:
                    break;
            }
        }
    }

    public override void Exit()
    {
        
    }

    public override void Initialize()
    {
        upgradeButtons = FindObjectsOfType<UpgradeButton>();
    }

    public override void Tick()
    {
        
    }

    public override void TurnFinishUnit()
    {
    }
}
