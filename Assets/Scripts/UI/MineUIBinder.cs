using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineUIBinder : UIObsever
{
    public Color turnedOffUI;
    public Color turnedOnUI;

    [SerializeField]
    private List<MineUISwitcher> mineUIButton = default;

    public override void BindUI(string text)
    {
        for (int i = 0; i < mineUIButton.Count; ++i)
        {
            if (ResourcesCheckerModuleSystem.CheckResources(mineUIButton[i].Type, false))
            {
                mineUIButton[i].TurnOnUI(turnedOnUI);

            } 
            else
            {
                mineUIButton[i].TurnOffUI(turnedOffUI);
            }
        }
    }
}
