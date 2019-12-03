using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementController : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0.1f, 0f);

    [SerializeField]
    private ShipDataController shipDataController = default;

    [SerializeField]
    private ShipTileController shipTileController = default;

    public bool UpdateShipPosition(RaycastHit hit)
    {
        HexTile hexTile = hit.transform.GetComponent<HexTile>();
        if (hexTile)
        {
            if (HexInRange(hexTile, shipDataController.ShipData.ShipDataContainer.GetMovementRange()) && shipTileController.CheckForTileAvailability(hexTile))
            {
                MoveToPosition(hexTile.transform.position, 4f);
                return true;
            }
        }
        return false;
    }

    private bool HexInRange(HexTile hexTile, float range)
    {
        if (Mathf.Abs(hexTile.transform.position.x - transform.position.x) <= range && Mathf.Abs(hexTile.transform.position.z - transform.position.z) <= range)
        {
            return true;
        }
        return false;
    }

    public void MoveToPosition(Vector3 position, float duration)
    {
        shipDataController.movePoints--;
        if (shipDataController.movePoints >= 0)
        {
            Vector3 dir = position - transform.position;
            dir.y = 0;
            transform.DORotateQuaternion(Quaternion.LookRotation(dir), duration);
            transform.DOMove(position + offset, duration * (transform.position - position).magnitude);
        }
    }
}
