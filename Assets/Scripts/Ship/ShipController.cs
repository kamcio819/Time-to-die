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
    private ShipRangeDrawer shipRangeDrawer = default;

    [SerializeField]
    private ShipOwnershipController shipOwnershipController = default;

    [SerializeField]
    private PlayerType playerType = default;

    [SerializeField]
    private ShipType shipType = default;

    private bool catchMovement = false;
    private bool catchAttack = false;
    private Camera cam;
    private CursorInput cursorInput;

    private Vector3 offset = new Vector3(0f, 0.2f, 0f);

    public PlayerType PlayerType { get => playerType; }
    public ShipType ShipType { get => shipType; }

    private void OnMouseDown()
    {
        if (playerType == PlayerType.PLAYER)
        {
            HandleUIPanel();

            if (uIShipController.Selected)
            {
                shipRangeDrawer.DrawMovementRange(false);
                shipRangeDrawer.DrawAttackRange(false);
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
        shipRangeDrawer.DrawAttackRange(false);
        shipRangeDrawer.DrawMovementRange(true);

        catchMovement = true;
        catchAttack = false;
    }

    public void ResetActions()
    {
        shipRangeDrawer.DrawAttackRange(false);
        shipRangeDrawer.DrawMovementRange(false);
        catchMovement = false;
        catchAttack = false;
    }

    public void ProcessAttack()
    {
        shipRangeDrawer.DrawMovementRange(false);
        shipRangeDrawer.DrawAttackRange(true);

        catchAttack = true;
        catchMovement = false;
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
            if(shipAttackingController.AttackPosition(hit, offset))
            {
                shipRangeDrawer.DrawAttackRange(false);
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
            if(shipMovementController.UpdateShipPosition(hit))
            {
                shipRangeDrawer.DrawMovementRange(false);
                catchMovement = false;
                uIShipController.ToggleUIPanel();
            }
        }
    }

    private Ray CreateRayFromCamera()
    {
        return cam.ScreenPointToRay(cursorInput.MousePosition);
    }

    public void SetOwner(PlayerType _playerType)
    {
        playerType = _playerType;
        shipDataController.SetData(playerType);
        shipOwnershipController.SetMaterial(playerType);
    }

}

