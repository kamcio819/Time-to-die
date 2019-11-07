using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIController : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> menuScreens;

    protected GameObject activeScreen;

    public virtual void OpenScreen(string screenName)
    {
        CloseScreens();
        activeScreen = menuScreens.Find(x => x.name == screenName);
        activeScreen.SetActive(true);
    }

    private void CloseScreens()
    {
        for(int i =0; i < menuScreens.Count; ++i)
        {
            menuScreens[i].SetActive(false);
        }
    }

    public virtual void CloseScreen(string screenName)
    {
        GameObject screen = menuScreens.Find(x => x.name == screenName);
        screen.SetActive(false);
        activeScreen = null;
    }
}
