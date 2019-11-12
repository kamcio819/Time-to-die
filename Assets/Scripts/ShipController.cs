using System;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private ShipData shipData = default;

    [SerializeField]
    private UIShipController uIShipController;

    [SerializeField]
    private ShipMovementController shipMovementController;

    [SerializeField]
    private ShipAttackingController shipAttackingController;

    private bool catchMovement = false;
    private bool catchAttack = false;
    private Camera cam;
    private CursorInput cursorInput;

    void OnMouseDown()
    {
        uIShipController.ToggleUIPanel();
    }

    private void Awake()
    {
        cam = GameObject.Find("MainCamera").GetComponent<Camera>();
        cursorInput = FindObjectOfType<CursorInput>();
    }

    public void DrawMovementRange()
    {
        // draws range

        catchMovement = true;
        catchAttack = false;
    }

    public void DrawAttackRange()
    {
        // draws range

        catchAttack = true;
        catchMovement = false;
    }

    private void Update()
    {
        if(catchMovement && cursorInput.leftMouseClicked)
        {
            UpdateShipPosition();
        }

        if(catchAttack && cursorInput.leftMouseClicked)
        {
            AttackPosition();
        }
    }

    private void AttackPosition()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.GetComponent<HexTile>())
            {
                shipAttackingController.AttackPosition(hit.point, 10f);
                catchAttack = false;
                uIShipController.ToggleUIPanel();
            }
        }
    }

    private void UpdateShipPosition()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.GetComponent<HexTile>())
            {
                shipMovementController.SetPosition(hit.point, 15f);
                catchMovement = false;
                uIShipController.ToggleUIPanel();
            }
        }
    }
}

