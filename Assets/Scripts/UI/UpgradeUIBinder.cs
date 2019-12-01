using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUIBinder : UIObsever
{
    public Color turnedOffUI;
    public Color turnedOnUI;

    [SerializeField]
    private List<UpgradeUISwitcher> upgradeUIButton = default;

    public override void BindUI(string text)
    {
        for (int i = 0; i < upgradeUIButton.Count; ++i)
        {
            if (ResourcesCheckerModuleSystem.CheckResources(upgradeUIButton[i].Type, false, PlayerType.PLAYER))
            {
                upgradeUIButton[i].TurnOnUI(turnedOnUI);

            } 
            else
            {
                upgradeUIButton[i].TurnOffUI(turnedOffUI);
            }
        }
    }
}
