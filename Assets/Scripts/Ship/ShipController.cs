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
    private ShipTileController shipTileController = default;

    [SerializeField]
    private PlayerType playerType;

    private bool catchMovement = false;
    private bool catchAttack = false;
    private Camera cam;
    private CursorInput cursorInput;

    private Vector3 offset = new Vector3(0f, 0.1f, 0f);

    public PlayerType PlayerType { get => playerType; }

    private void OnMouseDown()
    {
        if (playerType == PlayerType.PLAYER)
        {
            HandleUIPanel();

            if (uIShipController.Selected)
            {
                DrawMovementRange(false);
                DrawAttackRange(false);
            }
            uIShipController.ToggleUIPanel();
        }
    }

    private void HandleUIPanel()
    {
        if (cursorInput.SelectedObject && cursorInput.SelectedObject != gameObject)
        {
            cursorInput.SelectedObject.GetComponentInChildren<UIShipController>().HideUIPanel();
            cursorInput.SelectedObject.GetComponent<ShipController>().ResetActions();
        }
        cursorInput.SelectedObject = gameObject;
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
            if (tileController && hexTile && hexTile.tileType == MapSystem.Type.SEA && CheckForTileAvailability(hexTile))
            {
                if (flag)
                    tileController.ChangeColorOfTile(Color.gray);
                else
                    tileController.ResetTileColor();
            }
                
        }
    }

    private bool CheckForTileAvailability(HexTile hexTile)
    {
        if(shipTileController.OccupiedTiles.Contains(hexTile))
        {
            return true;
        }
        else
        {
            if (hexTile.availableToPlaceOn == MapSystem.AvailableToPlaceOn.YES)
            {
                return true;
            }
            else
            {
                return false;
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
        if(catchMovement && cursorInput.LeftMouseClicked)
        {
            UpdateShipPosition();
        }

        if(catchAttack && cursorInput.LeftMouseClicked)
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
                if (HexInRange(hexTile, shipDataController.ShipData.ShipDataContainer.GetMovementRange()) && CheckForTileAvailability(hexTile))
                {
                    shipMovementController.MoveToPosition(hexTile.transform.position, 4f);
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
        return cam.ScreenPointToRay(cursorInput.MousePosition);
    }

    public void SetOwner(PlayerType _playerType)
    {
        playerType = _playerType;
        shipDataController.SetData(playerType);
    }

}

