using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuController : UIController
{
    [SerializeField]
    private UIAnimationController animationController;

    public void ExitGame()
    {
        GameManager.Instance.LoadSceneSync("MainMenu");
    }

    public void ResumeGame()
    {
        animationController.DisableScreens();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            animationController.DisableScreens();
        }
    }
}
