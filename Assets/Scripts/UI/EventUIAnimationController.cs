using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUIAnimationController : MonoBehaviour
{
    [SerializeField]
    private PopUpMenu eventUI = default;

    [SerializeField]
    private Animator eventAnimator = default;

    public void OpenScreen()
    {
        AnimateUI();
    }

    private void AnimateUI()
    {
        StopAllCoroutines();
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        eventAnimator.SetTrigger("UIShow");
        AnimateUIHandle();
        yield return new WaitForSeconds(2.35f);
        eventAnimator.SetTrigger("UIHide");
        AnimateUIHandle();
    }

    private void AnimateUIHandle()
    {
        eventUI.TogglePopUpMenu();
    }
}
