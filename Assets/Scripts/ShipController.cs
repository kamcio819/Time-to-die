using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private ShipData shipData;

    [SerializeField]
    private Animator animator;

    private bool selected = true;

    void OnMouseDown()
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

