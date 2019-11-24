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

    [SerializeField]
    private CursorInput cursorInput = default;

    private bool mouseOver;
    private Vector2 pos;
    private Vector2 sizeModifier = Vector2.zero;
    private Camera cam;

    private const float sizeScaleModifier = 42f;

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
        UpdateMinimapSize();
        if(mouseOver && MouseInMinimap(cursorInput.mousePosition))
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(miniMap, cursorInput.mousePosition, cam, out pos);
            cursorRange.localPosition = pos;
            Vector2 divRange = cursorRange.localPosition / miniMap.sizeDelta;
            cameraController.SetCameraPosition(Math.Abs(divRange.x), Math.Abs(divRange.y));
        }
    }

    private void UpdateMinimapSize()
    {
        if (cursorInput.scrollWheelInput != 0)
        {
            sizeModifier.x = Mathf.Clamp(cursorRange.sizeDelta.x + -cursorInput.scrollWheelInput * sizeScaleModifier, 60, 110);
            sizeModifier.y = Mathf.Clamp(cursorRange.sizeDelta.y + -cursorInput.scrollWheelInput * sizeScaleModifier, 30, 40);

            cursorRange.sizeDelta = sizeModifier;
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
