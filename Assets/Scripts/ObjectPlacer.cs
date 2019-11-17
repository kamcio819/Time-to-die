using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private CursorInput cursorInput = default;

    [SerializeField]
    private KeyboardInput keyboardInput = default;

    [SerializeField]
    private Camera cam = default;

    [SerializeField]
    private LayerMask layerMask;

    private GameObject currentObj;
    private Vector3 offset = new Vector3(0f, 0.1f, 0f);

    private float timer = 0f;

    public void SetCurentObj(GameObject cs)
    {
        currentObj = cs;
    }

    public void OnUpdate()
    {
        if(currentObj)
        {
            timer += 0.15f;
            UpdatePosition();
            currentObj.transform.RotateAround(currentObj.transform.position, Vector3.up, keyboardInput.yDeltaShip * Time.deltaTime);
            if (timer > 0.5f && cursorInput.leftMouseClicked && CorrectPosition())
            {
                timer = 0f;
                currentObj = null;
            }
        }     
    }

    private bool CorrectPosition()
    {
        return true;
    }

    private void UpdatePosition()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, layerMask))
        {
            if(hit.transform.GetComponent<HexTile>())
            {
                currentObj.transform.position = hit.transform.position + offset;
            }
        }
    }
}
