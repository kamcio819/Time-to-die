using System;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private UIShipController uIShipController = default;

    [SerializeField]
    private ShipDataController shipDataController = default;

    [SerializeField]
    private ShipMovementController shipMovementController = default;

    [SerializeField]
    private ShipAttackingController shipAttackingController = default;

    [SerializeField]
    private PlayerType playerType;

    private bool catchMovement = false;
    private bool catchAttack = false;
    private Camera cam;
    private CursorInput cursorInput;

    private Vector3 offset = new Vector3(0f, 0.1f, 0f);

    private void OnMouseDown()
    {
        HandleUIPanel();

        if (uIShipController.Selected)
        {
            DrawMovementRange(false);
            DrawAttackRange(false);
        }
        uIShipController.ToggleUIPanel();
    }

    private void HandleUIPanel()
    {
        if (cursorInput.selectedShip && cursorInput.selectedShip != gameObject)
        {
            cursorInput.selectedShip.GetComponentInChildren<UIShipController>().HideUIPanel();
            cursorInput.selectedShip.GetComponent<ShipController>().ResetActions();
        }
        cursorInput.selectedShip = gameObject;
    }

    private void Awake()
    {
        cam = GameObject.Find("MainCamera").GetComponent<Camera>();
        cursorInput = FindObjectOfType<CursorInput>();
    }

    public void ProcessMovement()
    {
        DrawAttackRange(false);
        DrawMovementRange(true);

        catchMovement = true;
        catchAttack = false;
    }

    public void ResetActions()
    {
        DrawAttackRange(false);
        DrawMovementRange(false);
        catchMovement = false;
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
        DrawMovementRange(false);
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
                    shipAttackingController.AttackPosition(hexTile.transform.position + offset, 1f);
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
        return cam.ScreenPointToRay(cursorInput.mousePosition);
    }

    public void SetOwner(PlayerType _playerType)
    {
        playerType = _playerType;
    }

}

