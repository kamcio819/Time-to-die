using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuController : UIController
{
    [SerializeField]
    private Transform openedPanelParent;

    [SerializeField]
    private Transform disabledPanelParent;

    public override void OpenScreen(string screenName)
    {
        for(int i = 0; i < menuScreens.Count; ++i)
        {
            menuScreens[i].transform.SetParent(disabledPanelParent);
        }
        activeScreen = menuScreens.Find(x => x.name == screenName);
        activeScreen.transform.SetParent(openedPanelParent);
    }
}
