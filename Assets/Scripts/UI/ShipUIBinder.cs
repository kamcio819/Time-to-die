using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUIBinder : UIObsever
{
    public Color turnedOffUI;
    public Color turnedOnUI;

    [SerializeField]
    private List<ShipUISwitcher> shipButtons = default;

    public override void BindUI(string text)
    {
        for(int i = 0; i < shipButtons.Count; ++i)
        {
            if(ResourcesCheckerModuleSystem.CheckResources(shipButtons[i].Type, false))
            {
                shipButtons[i].TurnOnUI(turnedOnUI);

            } 
            else
            {
                shipButtons[i].TurnOffUI(turnedOffUI);
            }
        }
    }
}
