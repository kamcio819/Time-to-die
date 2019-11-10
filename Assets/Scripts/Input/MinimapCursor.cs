using System;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class MinimapCursor : MonoBehaviour,
    IPointerUpHandler,
    IPointerDownHandler
{
    [SerializeField]
    private RectTransform cursorRange = default;

    [SerializeField]
    private RectTransform miniMap = default;

    [SerializeField]
    private CameraController cameraController = default;

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

    public void Update()
    {
        UpdateMinimapCursorPosition();
        if(mouseOver && MouseInMinimap(Input.mousePosition))
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(miniMap, Input.mousePosition, cam, out pos);
            cursorRange.localPosition = pos;
            Vector2 divRange = cursorRange.localPosition / miniMap.sizeDelta;
            cameraController.SetCameraPosition(Math.Abs(divRange.x), Math.Abs(divRange.y));
        }
    }

    private void UpdateMinimapCursorPosition()
    {
        var div = cameraController.GetDivisions();
        Vector3 newPos = new Vector3(miniMap.sizeDelta.x * div.Item1, miniMap.sizeDelta.y * div.Item2, 0);
        cursorRange.DOLocalMove(newPos, 0.1f);
    }

    private bool MouseInMinimap(Vector3 mousePosition)
    {
        if (mousePosition.x > 1600 && mousePosition.x < 1920 && mousePosition.y < 250 && mousePosition.y > 0)
            return true;
        else
            return false;
    }
}
