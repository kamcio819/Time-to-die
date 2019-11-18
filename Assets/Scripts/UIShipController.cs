using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShipController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private bool selected = true;

    public bool Selected { get => selected; }

    public void ToggleUIPanel()
    {
        selected = !selected;
        if (!selected)
        {
            animator.SetTrigger("ShowPanel");
        } else
        {
            animator.SetTrigger("HidePanel");
        }
    }
}
