using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class CursorInput : MonoBehaviour,
    IPointerUpHandler,
    IPointerDownHandler
{
    [SerializeField]
    private RectTransform cusorRange;

    [SerializeField]
    private RectTransform miniMap;

    private bool mouseOver;
    private Vector2 pos;

    private Camera cam;

    public void OnPointerDown(PointerEventData eventData)
    {
        mouseOver = true;
        cam = eventData.enterEventCamera;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mouseOver = false;
    }

    private void Update()
    {
        if(mouseOver && MouseInMinimap(Input.mousePosition))
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(miniMap, Input.mousePosition, cam, out pos);
            cusorRange.localPosition = pos;
        }
    }

    private bool MouseInMinimap(Vector3 mousePosition)
    {
        if (mousePosition.x > 1600 && mousePosition.x < 1920 && mousePosition.y < 250 && mousePosition.y > 0)
            return true;
        else
            return false;
    }
}
