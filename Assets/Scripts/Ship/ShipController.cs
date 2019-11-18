using System;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private UIShipController uIShipController;

    [SerializeField]
    private ShipDataController shipDataController;

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

        Collider[] tiles = Physics.OverlapSphere(transform.position, shipDataController.ShipData.ShipDataContainer.GetMovementRange());
        for(int i = 0; i < tiles.Length; ++i)
        {
            TileController tileController = tiles[i].GetComponent<TileController>();
            HexTile hexTile = tiles[i].GetComponent<HexTile>();
            if (tileController && hexTile && hexTile.tileType == MapSystem.Type.SEA)
                tileController.ChangeColorOfTile(Color.gray);
        }

        catchMovement = true;
        catchAttack = false;
    }

    public void DrawAttackRange()
    {
        // draws range

        Collider[] tiles = Physics.OverlapSphere(transform.position, shipDataController.ShipData.ShipDataContainer.GetAttackRange());
        for (int i = 0; i < tiles.Length; ++i)
        {
            TileController tileController = tiles[i].GetComponent<TileController>();
            if (tileController)
                tileController.ChangeColorOfTile(Color.yellow);
        }

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
        Ray ray = CreateRayFromCamera();

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.GetComponent<HexTile>())
            {
                shipAttackingController.AttackPosition(hit.transform.position, 10f);
                catchAttack = false;
                uIShipController.ToggleUIPanel();
            }
        }
    }

    private void UpdateShipPosition()
    {
        RaycastHit hit;
        Ray ray = CreateRayFromCamera();

        if (Physics.Raycast(ray, out hit))
        {
            HexTile hexTile = hit.transform.GetComponent<HexTile>();
            if (hexTile)
            {
                shipMovementController.MoveToPosition(hexTile.transform.position, 10f);
                catchMovement = false;
                uIShipController.ToggleUIPanel();
            }
        }
    }

    private Ray CreateRayFromCamera()
    {
        return cam.ScreenPointToRay(Input.mousePosition);
    }
}

