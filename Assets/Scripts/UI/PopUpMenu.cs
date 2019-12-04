using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PopUpMenu : MonoBehaviour
{
    [SerializeField]
    private bool active = false;

    [SerializeField]
    private RectTransform rectTransform = default;

    [SerializeField]
    private float x = default;

    [SerializeField]
    private float y = default;

    [SerializeField]
    private float xBegin = default;

    public void TogglePopUpMenu()
    {
        if(active)
        {
            rectTransform.DOAnchorPos(new Vector3(xBegin, y, 0f), 0.3f);
            active = false;
        }
        else
        {
            rectTransform.DOAnchorPos(new Vector3(x, y, 0f), 0.3f);
            active = true;
        }
    }

    public void HidePopUpMenu()
    {
        rectTransform.DOAnchorPos(new Vector3(xBegin, y, 0f), 0.3f);
        active = false;
    }
}
