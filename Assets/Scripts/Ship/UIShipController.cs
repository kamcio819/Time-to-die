using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShipController : MonoBehaviour
{
    [SerializeField]
    private Animator animator = default;

    public bool selected = true;

    public bool Selected { get => selected; }

    public void ToggleUIPanel()
    {
        if (!selected)
        {
            animator.SetTrigger("ShowPanel");
        } else
        {
            animator.SetTrigger("HidePanel");
        }
        selected = !selected;
    }

    public void HideUIPanel()
    {
        if(!selected)
        {
            return;
        }
        selected = false;
        animator.SetTrigger("HidePanel");
    }
}
