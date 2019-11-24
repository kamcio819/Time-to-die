using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUIAnimationController : MonoBehaviour
{
    [SerializeField]
    private PopUpMenu eventUI = default;

    public void OpenScreen()
    {
        AnimateUI();
    }

    private void AnimateUI()
    {
        AnimateUIHandle();       
    }

    private void AnimateUIHandle()
    {
        eventUI.TogglePopUpMenu();
    }
}
