using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private ShipData shipData = default;

    [SerializeField]
    private Animator animator = default;

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

