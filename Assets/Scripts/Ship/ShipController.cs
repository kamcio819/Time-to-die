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
        if(uIShipController.Selected)
        {
            DrawMovementRange(false);
            DrawAttackRange(false);
        }
    }

    private void Awake()
    {
        cam = GameObject.Find("MainCamera").GetComponent<Camera>();
        cursorInput = FindObjectOfType<CursorInput>();
    }

    public void ProcessMovement()
    {
        DrawMovementRange(true);

        catchMovement = true;
        catchAttack = false;
    }

    public void DrawMovementRange(bool flag)
    {
        Collider[] tiles = Physics.OverlapSphere(transform.position, shipDataController.ShipData.ShipDataContainer.GetMovementRange());
        for (int i = 0; i < tiles.Length; ++i)
        {
            TileController tileController = tiles[i].GetComponent<TileController>();
            HexTile hexTile = tiles[i].GetComponent<HexTile>();
            if (tileController && hexTile && hexTile.tileType == MapSystem.Type.SEA)
            {
                if (flag)
                    tileController.ChangeColorOfTile(Color.gray);
                else
                    tileController.ResetTileColor();
            }
                
        }
    }

    public void ProcessAttack()
    {
        DrawAttackRange(true);

        catchAttack = true;
        catchMovement = false;
    }

    public void DrawAttackRange(bool flag)
    {
        Collider[] tiles = Physics.OverlapSphere(transform.position, shipDataController.ShipData.ShipDataContainer.GetAttackRange());
        for (int i = 0; i < tiles.Length; ++i)
        {
            TileController tileController = tiles[i].GetComponent<TileController>();
            if (tileController)
            {
                if (flag)
                    tileController.ChangeColorOfTile(Color.yellow);
                else
                    tileController.ResetTileColor();
            }
        }
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
            HexTile hexTile = hit.transform.GetComponent<HexTile>();
            if (hexTile)
            {
                if (HexInRange(hexTile, shipDataController.ShipData.ShipDataContainer.GetAttackRange()))
                {
                    shipAttackingController.AttackPosition(hexTile.transform.position, 6f);
                }
                DrawAttackRange(false);
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
                if (HexInRange(hexTile, shipDataController.ShipData.ShipDataContainer.GetMovementRange()))
                {
                    shipMovementController.MoveToPosition(hexTile.transform.position, 10f);
                }
                DrawMovementRange(false);
                catchMovement = false;
                uIShipController.ToggleUIPanel();
            }
        }
    }

    private bool HexInRange(HexTile hexTile, float range)
    {
        if(Mathf.Abs(hexTile.transform.position.x - transform.position.x) <= range && Mathf.Abs(hexTile.transform.position.z - transform.position.z) <= range)
        {
            return true;
        }
        return false;
    }

    private Ray CreateRayFromCamera()
    {
        return cam.ScreenPointToRay(Input.mousePosition);
    }
}

