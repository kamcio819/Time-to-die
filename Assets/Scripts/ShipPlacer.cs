using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPlacer : MonoBehaviour
{
    [SerializeField]
    private CursorInput cursorInput = default;

    [SerializeField]
    private KeyboardInput keyboardInput = default;

    [SerializeField]
    private Camera cam = default;

    private GameObject currentShip;

    public void SetCurrentShip(GameObject cs)
    {
        currentShip = cs;
    }

    public void OnUpdate()
    {
        if(currentShip)
        {
            UpdateShipPosition();
            currentShip.transform.RotateAround(currentShip.transform.position, Vector3.up, keyboardInput.yDeltaShip * Time.deltaTime);
        }
        if (cursorInput.leftMouseClicked && CorrectPosition())
        {
            currentShip = null;
        }
    }

    private bool CorrectPosition()
    {
        return true;
    }

    private void UpdateShipPosition()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.GetComponent<HexTile>())
            {
                currentShip.transform.position = hit.point;
            }
        }
    }
}
