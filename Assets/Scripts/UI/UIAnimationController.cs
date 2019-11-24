using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIAnimationController : MonoBehaviour
{
    private enum GameUI
    {
        PauseMenu,
        BuildingsMenu,
        UpgradeMenu,
        ShipsMenu,
    }

    [SerializeField]
    private GameUI currentGameUI;

    [SerializeField]
    private List<PopUpMenu> screens = default;

    private PopUpMenu currentScreen;

    public void OpenScreen(string name)
    {
        Enum.TryParse(name, out currentGameUI);
        currentScreen = screens.Find(x => x.gameObject.name.Equals(currentGameUI.ToString()));
        AnimateUI();
    }

    private void AnimateUI()
    {
        if (currentScreen)
        {
            AnimateUIHandle();
        }
    }

    private void AnimateUIHandle()
    {
        for (int i = 0; i < screens.Count; ++i)
        {
            if (screens[i].Equals(currentScreen))
            {
                screens[i].TogglePopUpMenu();
            } else
            {
                screens[i].HidePopUpMenu();
            }
        }
    }

    public void DisableScreens()
    {
        AnimateUIHandle();
    }

}
